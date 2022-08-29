using DevExpress.Utils.MVVM.UI;
using Polyathlon.ViewModels;
using Polyathlon.Models.Entities;
using Region = Polyathlon.Models.Entities.Region;

using DevExpress.Mvvm;

namespace Polyathlon.Views
{
    [ViewType("RegionCollectionView")]
    public partial class RegionCollectionView : BaseViewWithWinUIButtons, ISupportParameter
    {
        public object Parameter { get; set; }
        public RegionCollectionView() {
            InitializeComponent();
            gridView.SetupCollectionGrid();
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            if(!mvvmContext.IsDesignMode) 
                InitBindings();
        }
        void InitBindings() {
            //mvvmContext.ViewModelConstructorParameter = new();
            var fluentAPI = mvvmContext.OfType<RegionCollectionViewModel>();
            mvvmContext.BindCollectionGrid<RegionCollectionViewModel, RegionViewEntity, Region>(gridView, regionBindingSource);
            fluentAPI.SetObjectDataSourceBinding(regionBindingSource, x => x.Entities);
            fluentAPI.SetBinding(regionBindingSource, rbs => rbs.DataSource, x => x.Entities);
            //fluentAPI.SetBinding(gridView, gv => gv.LoadingPanelVisible, x => x.IsLoading);
            //fluentAPI.SetBinding(gridView, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            fluentAPI.SetBinding(titleLabelItem1, t => t.Text, x => x.ModuleDescription.Tile.Title);
            //fluentAPI.SetBinding(titleLabelItem1, t => t.Text, x => x.IsLoading);

            //gridControl.DataSource = regionBindingSource;
            //regionBindingSource.DataSource = fluent.ViewModel.Entities;
            //fluentAPI.SetBinding(gridControl, gControl => gControl.DataSource, x => x.Entities);

            //var fluentAPI = mvvmContext.OfType<RegionCollectionViewModel>();
            //fluentAPI.SetBinding(labelName, label => label.Text, x => x.SelectedEntity.Name);
            //customerDetailsComboBoxEdit.Properties.Items.AddEnum<CollectionDetailKind>();
            //customerDetailsComboBoxEdit.SelectedIndex = 0;

            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.New());
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, task) => x.Edit(task), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, entity) => x.Edit(entity), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], (x, entity) => x.Delete(entity), x => x.SelectedEntity);
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], x => x.CustomFilter(), "CustomFilter");
        }
        //void customerDetailsComboBoxEdit_SelectedIndexChanged(object sender, System.EventArgs e) {
        //    CollectionDetailKind kind = (CollectionDetailKind)customerDetailsComboBoxEdit.EditValue;
        //    if(kind == CollectionDetailKind.Contacts) {
        //        lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        //        lciStores.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        //    }
        //    else {
        //        lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        //        lciStores.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        //    }
        //}
    }
}
