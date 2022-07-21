using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;

namespace Polyathlon.ViewModels {
    public abstract class FilterViewModelBase {
        public Action NavigateAction { get; set; }
        protected IFilterModelPageSpecificSettings settings;
        public FilterViewModelBase(IFilterModelPageSpecificSettings settings)
        {
            this.settings = settings;
            Init();
        }

        protected virtual void Init() {
            StaticFilters = CreateFilterItems(settings.StaticFilters);
            CustomFilters = CreateFilterItems(settings.CustomFilters);
        }

        public virtual IList<FilterItem> StaticFilters { get; protected set; }
        public virtual IList<FilterItem> CustomFilters { get; protected set; }
        protected virtual void OnStaticFiltersChanged()
        {
            SelectedItem = StaticFilters.FirstOrDefault();
        }

        public virtual FilterItem SelectedItem { get; set; }
        public virtual FilterItem ActiveFilterItem { get; set; }
        protected virtual void OnSelectedItemChanged() {
        }

        protected virtual void UpdateFilterExpression() {
        }

        protected List<FilterItem> CreateFilterItems(IEnumerable<FilterInfo> filterInfos) {
            var infos = filterInfos ?? new List<FilterInfo>();
            return new List<FilterItem>(infos.Select(x => CreateFilterItem(x.Name, CriteriaOperator.Parse(x.FilterCriteria), x.ImageUri)));
        }

        protected virtual FilterItem CreateFilterItem(string name, CriteriaOperator filterCriteria, string imageUri) {
            return FilterItem.Create(name, filterCriteria, imageUri);
        }

        protected FilterInfoList SaveToSettings(List<FilterItem> filters) {
            return new FilterInfoList(filters.Select(fi => new FilterInfo { Name = fi.Name, FilterCriteria = CriteriaOperator.ToString(fi.FilterCriteria), ImageUri = fi.ImageUri }));
        }

        #region Filter Item ViewModel

        public class FilterItem {
            protected FilterItem(string name, CriteriaOperator filterCriteria, string imageUri) {
                this.Name = name;
                this.FilterCriteria = filterCriteria;
                this.ImageUri = imageUri;
            }

            public virtual string Name { get; set; }
            public virtual CriteriaOperator FilterCriteria { get; set; }
            public virtual string ImageUri { get; set; }
            public virtual int Count { get; set; }
            
            public static FilterItem Create(string name, CriteriaOperator filterCriteria, string imageUri) {
                return ViewModelSource.Create(() => new FilterItem(name, filterCriteria, imageUri));
            }

            public FilterItem Clone()
            {
                FilterItem item = FilterItem.Create(Name, FilterCriteria, ImageUri);
                item.Count = this.Count;
                return item;
            }
        }

        #endregion Filter Item ViewModel

        public virtual void SetViewModel(object viewModel) {
        }
    }
}
