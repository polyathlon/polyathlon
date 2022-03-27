using System;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Data.Utils;
using DevExpress.DevAV.Common.ViewModel;
using DevExpress.DevAV.DevAVDbDataModel1;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace DevExpress.DevAV.ViewModels {
    public abstract class FilterViewModel<TEntity, TProjection> : FilterViewModelBase
        where TEntity : class
        where TProjection : class {
        protected FilterViewModel(IFilterModelPageSpecificSettings settings, Action<object, Action> registerEntityChangedMessageHandler)
            : base(settings) {
                registerEntityChangedMessageHandler(this, () => UpdateFilters());
                Messenger.Default.Register<CreateCustomFilterMessage<TEntity>>(this, message => CreateCustomFilter());
        }
        protected ReadOnlyCollectionViewModel<TEntity, TProjection, IDevAVDbUnitOfWork> CollectionViewModel {
            get { return (ReadOnlyCollectionViewModel<TEntity, TProjection, IDevAVDbUnitOfWork>)viewModel; }
        }
        protected override void OnSelectedItemChanged() {
            ActiveFilterItem = (SelectedItem != null) ? SelectedItem.Clone() : null;
            UpdateFilterExpression();
            if(NavigateAction != null)
                NavigateAction();
        }
        protected override void UpdateFilterExpression() {
            if(CollectionViewModel != null) {
                var criteria = GetSelectedCriteria();
                if(!object.ReferenceEquals(criteria, null))
                    CollectionViewModel.FilterExpression = GetFilterExpression(criteria);
                else
                    CollectionViewModel.FilterExpression = null;
            }
        }
        object viewModel;
        public override void SetViewModel(object viewModel) {
            this.viewModel = viewModel;
            var viewModelContainer = viewModel as IFilterTreeViewModelContainer<TEntity, TProjection>;
            if(viewModelContainer != null)
                viewModelContainer.FilterViewModel = this;
            UpdateFilters();
            UpdateFilterExpression();
        }
        void UpdateFilters() {
            foreach(var item in StaticFilters)
                item.Count = GetEntityCount(item.FilterCriteria);
        }
        protected override FilterViewModelBase.FilterItem CreateFilterItem(string name, CriteriaOperator filterCriteria, string imageUri) {
            var filterItem = base.CreateFilterItem(name, filterCriteria, imageUri) as FilterItem;
            if(CollectionViewModel != null)
                filterItem.Count = GetEntityCount(filterCriteria);
            return filterItem;
        }
        int GetEntityCount(CriteriaOperator filterCriteria) {
            return CollectionViewModel.GetEntities(GetFilterExpression(filterCriteria)).Count();
        }
        CriteriaOperator GetSelectedCriteria() {
            return (ActiveFilterItem != null) ? ActiveFilterItem.FilterCriteria : null;
        }
        Expression<Func<TEntity, bool>> GetFilterExpression(CriteriaOperator criteria) {
            return CriteriaOperatorToExpressionConverter.GetGenericWhere<TEntity>(criteria);
        }
        public void CreateCustomFilter() {
            FilterItem filterItem = CreateFilterItem(string.Empty, null, null);
            var filterViewModel = CreateCustomFilterViewModel(filterItem, true);
            ShowFilter(filterItem, filterViewModel, () => AddNewCustomFilter(filterItem));
        }
        CustomFilterViewModel CreateCustomFilterViewModel(FilterItem existing, bool save) {
            var viewModel = CustomFilterViewModel.Create(typeof(TEntity));
            viewModel.FilterCriteria = existing.FilterCriteria;
            viewModel.FilterName = existing.Name;
            viewModel.Save = save;
            viewModel.SetParentViewModel(this);
            return viewModel;
        }
        void ShowFilter(FilterItem filterItem, CustomFilterViewModel filterViewModel, Action onSave) {
            if(FilterDialogService.ShowDialog(MessageButton.OKCancel, "Create Custom Filter", DevAVDbViewModel.CustomFilterViewDocumentType, filterViewModel) != MessageResult.OK)
                return;
            filterItem.FilterCriteria = filterViewModel.FilterCriteria;
            filterItem.Name = filterViewModel.FilterName;
            SelectedItem = filterItem;
            if(filterViewModel.Save) {
                onSave();
                UpdateFilters();
            }
        }
        IDialogService FilterDialogService { get { return this.GetService<IDialogService>("FilterDialogService"); } }
        const string NewFilterName = @"New Filter";
        void AddNewCustomFilter(FilterItem filterItem) {
            if(string.IsNullOrEmpty(filterItem.Name)) {
                int prevIndex = CustomFilters.Select(fi => Regex.Match(fi.Name, NewFilterName + @" (?<index>\d+)")).Where(m => m.Success).Select(m => int.Parse(m.Groups["index"].Value)).DefaultIfEmpty(0).Max();
                filterItem.Name = NewFilterName + " " + (prevIndex + 1);
            }
            else {
                var existing = CustomFilters.FirstOrDefault(fi => fi.Name == filterItem.Name);
                if(existing != null)
                    CustomFilters.Remove(existing);
            }
            CustomFilters.Add(filterItem);
            SaveCustomFilters();
        }
        void SaveCustomFilters() {
            settings.CustomFilters = SaveToSettings(CustomFilters);
            settings.SaveSettings();
        }

        FilterInfoList SaveToSettings(IList<FilterItem> filters) {
            return new FilterInfoList(filters.Select(fi => new FilterInfo { Name = fi.Name, FilterCriteria = CriteriaOperator.ToString(fi.FilterCriteria) }));
        }
    }
    public abstract class FilterViewModel<TEntity> : FilterViewModel<TEntity, TEntity>
        where TEntity : class {
        protected FilterViewModel(IFilterModelPageSpecificSettings settings, Action<object, Action> registerEntityChangedMessageHandler)
            : base(settings, registerEntityChangedMessageHandler) {
        }
    }
    
    public interface IFilterTreeViewModelContainer<TEntity, TProjection>
        where TEntity : class
        where TProjection : class {
        FilterViewModel<TEntity, TProjection> FilterViewModel { get; set; }
    }
    public interface IFilterTreeViewModelContainer<TEntity> : IFilterTreeViewModelContainer<TEntity, TEntity>
        where TEntity : class {
    }

    public class CreateCustomFilterMessage<TEntity> where TEntity : class {
    }
}
