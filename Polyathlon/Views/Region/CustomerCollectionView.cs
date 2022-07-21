using DevExpress.DevAV.ViewModels;
using DevExpress.Utils.MVVM.UI;
using Polyathlon.Views;

namespace Polyathlon.Views
{
    [ViewType("CustomerCollectionView")]
    public partial class CustomerCollectionView : BaseViewWithWinUIButtons {
        public CustomerCollectionView() {
            InitializeComponent();
            
            gridView.SetupCollectionGrid();
            tvEmployee.SetupTileView();
            tvStores.SetupTileView();
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            
            if(!mvvmContext.IsDesignMode) 
                InitBindings();
        }
        void InitBindings() {
            mvvmContext.BindCollectionGrid<CustomerCollectionViewModel, Customer, CustomerInfoWithSales>(gridView, customerBindingSource);
            var fluentAPI = mvvmContext.OfType<CustomerCollectionViewModel>();
            fluentAPI.SetBinding(labelName, label => label.Text, x => x.SelectedEntity.Name);
            customerDetailsComboBoxEdit.Properties.Items.AddEnum<CollectionDetailKind>();
            customerDetailsComboBoxEdit.SelectedIndex = 0;

            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.New());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, task) => x.Edit(task), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], x => x.CustomFilter(), "CustomFilter");
        }
        void customerDetailsComboBoxEdit_SelectedIndexChanged(object sender, System.EventArgs e) {
            CollectionDetailKind kind = (CollectionDetailKind)customerDetailsComboBoxEdit.EditValue;
            if(kind == CollectionDetailKind.Contacts) {
                lciEmployee.Visibility = XtraLayout.Utils.LayoutVisibility.Always;
                lciStores.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
            }
            else {
                lciEmployee.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
                lciStores.Visibility = XtraLayout.Utils.LayoutVisibility.Always;
            }
        }
    }
}
