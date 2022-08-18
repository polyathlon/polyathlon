using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using DevExpress.Utils.MVVM.UI;
using System;
using Polyathlon.ViewModels;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.Views {
    [ViewType("RegionView")]
    public partial class RegionView : BaseViewWithWinUIButtons {
        public RegionView() {
            InitializeComponent();
            dataLayoutControl.SetupLayoutControl();
            //orderGridView.SetupCollectionGrid();
            if(!mvvmContext.IsDesignMode)
                InitBindings();
        }
        void InitBindings() {
            var fluentAPI = mvvmContext.OfType<RegionViewModel>();
            //mapView.SetViewModel(fluentAPI.ViewModel.MapViewModel);
            //mapView.MapTemplate = MapExtension.CreateHomeOfficeItemForCustomer;
            fluentAPI.SetObjectDataSourceBinding(customerBindingSource, x => x.Entity, x => x.Update());
            //fluentAPI.SetBinding(NameTextEdit, l => l.EditValue, x => x.Entity.Test);
            fluentAPI.BindCommand(backWindowsUIButtonPanel.Buttons[0] as WindowsUIButton, x => x.Close());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.SaveAndClose());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], x => x.Close(), "Cancel");
            //fluentAPI.SetBinding(ordersGridControl, g => g.DataSource, x => x.CustomerOrdersDetails.Entities);
            //fluentAPI.SetBinding(dateTimeChartRangeControlClient.DataProvider, d => d.DataSource, x => x.CustomerOrdersDetails.Entities);
            fluentAPI.SetBinding(customerNameSimpleLabelItem, l => l.Text, x => x.Title);
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3] as WindowsUIButton, x => x.ShowOrders(), "OrderList");
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[4] as WindowsUIButton, x => x.ShowStores(), "SalesMap");
            //fluentAPI.SetTrigger(x => x.DetailKind, (v) =>
            //{
            //    if (v == DetailKind.Orders) {
            //        ordersLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //        storesLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    }
            //    else {
            //        storesLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //        ordersLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //    }
            //});
            //fluentAPI.WithEvent<RangeControl, RangeControlRangeEventArgs>(rangeControl, "RangeChanged")
            //    .SetBinding(x => x.DateRange,
            //        args => new DateRange((DateTime)args.Range.Minimum, (DateTime)args.Range.Maximum),
            //        (rangeCtrl, range) =>
            //        {
            //            rangeCtrl.SelectedRange = new RangeControlRange(range.Minimum, range.Maximum);
            //        });
            //fluentAPI.SetBinding(orderGridView, view => view.ActiveFilterCriteria, x => x.DateRange, range => ConverterExtensions.ConvertEditRangeToFilterCriteria(range, "OrderDate"));
        }


    }
}
