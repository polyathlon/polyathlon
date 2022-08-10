using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using DevExpress.Utils.MVVM.UI;
using System;
using Polyathlon.ViewModels;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.Views
{
    [ViewType("ChangeUserView")]
    public partial class ChangeUserView : BaseViewWithWinUIButtons
    {
        public ChangeUserView()
        {
            InitializeComponent();
            dataLayoutControl.SetupLayoutControl();
            if(!mvvmContext.IsDesignMode)
                InitBindings();
        }
        
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ChangeUserViewModel>();
            fluentAPI.SetObjectDataSourceBinding(userBindingSource,
                                                 x => x.CurrentUser,
                                                 x => x.Update());

            fluentAPI.ViewModel.Init();
            //mapView.SetViewModel(fluentAPI.ViewModel.MapViewModel);
            //mapView.MapTemplate = MapExtension.CreateHomeOfficeItemForCustomer;
            //fluentAPI.SetObjectDataSourceBinding(customerBindingSource, x => x.Entity, x => x.Update());
            //fluentAPI.BindCommand(backWindowsUIButtonPanel.Buttons[0] as WindowsUIButton, x => x.Close());
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.SaveAndClose());
            //fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], x => x.Close(), "Cancel");
        }
    }
}
