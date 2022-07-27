using DevExpress.Utils.MVVM.UI;
using Polyathlon.ViewModels;
using Polyathlon.DataModel.Entities;


namespace Polyathlon.Views
{
    [ViewType("RegionCollectionView")]
    public partial class RegionCollectionView : BaseViewWithWinUIButtons {
        public RegionCollectionView() {
            InitializeComponent();
            
            gridView.SetupCollectionGrid();
            //tvEmployee.SetupTileView();
            //tvStores.SetupTileView();
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            
            if(!mvvmContext.IsDesignMode) 
                InitBindings();
        }
        void InitBindings() {
            var fluent = mvvmContext.OfType<RegionCollectionViewModel>();
            fluent.SetBinding(gridView, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            fluent.SetBinding(gridControl, gControl => gControl.DataSource, x => x.Entities);
           // mvvmContext.BindCollectionGridMy<RegionCollectionViewModel, DataModel.Entities.Region, DataModel.Entities.Region>(gridView, regionBindingSource);
            //var fluentAPI = mvvmContext.OfType<RegionCollectionViewModel>();
            //fluentAPI.SetBinding(labelName, label => label.Text, x => x.SelectedEntity.Name);
            //customerDetailsComboBoxEdit.Properties.Items.AddEnum<CollectionDetailKind>();
            //customerDetailsComboBoxEdit.SelectedIndex = 0;

            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.New());
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, task) => x.Edit(task), x => x.SelectedEntity);
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], x => x.CustomFilter(), "CustomFilter");
        }
        void customerDetailsComboBoxEdit_SelectedIndexChanged(object sender, System.EventArgs e) {
            CollectionDetailKind kind = (CollectionDetailKind)customerDetailsComboBoxEdit.EditValue;
            if(kind == CollectionDetailKind.Contacts) {
                lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciStores.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else {
                lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciStores.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }
    }
}
