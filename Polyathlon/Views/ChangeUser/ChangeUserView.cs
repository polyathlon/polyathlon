using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.Utils.MVVM.UI;

using Polyathlon.ViewModels;

namespace Polyathlon.Views
{
    [ViewType("ChangeUserView")]
    public partial class ChangeUserView : BaseViewWithWinUIButtons
    {
        public ChangeUserView()
        {
            InitializeComponent();
            dataLayoutControl.SetupLayoutControl();
            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }

        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ChangeUserViewModel>();
            fluentAPI.SetObjectDataSourceBinding(userBindingSource,
                                                 x => x.CurrentUser,
                                                 x => x.Update());

            fluentAPI.ViewModel.Init();
            fluentAPI.SetObjectDataSourceBinding(userBindingSource, x => x.CurrentUser, x => x.Update());
        }
    }
}