using DevExpress.XtraBars.Docking2010;
using DevExpress.Utils.MVVM.UI;

using Polyathlon.ViewModels;

namespace Polyathlon.Views
{
    [ViewType("ClubView")]
    public partial class ClubView : BaseViewWithWinUIButtons
    {
        public ClubView()
        {
            InitializeComponent();
            dataLayoutControl.SetupLayoutControl();
            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }

        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ClubViewModel>();
            fluentAPI.SetObjectDataSourceBinding(customerBindingSource, x => x.ViewEntity, x => x.Update());

            fluentAPI.BindCommand(backWindowsUIButtonPanel.Buttons[0] as WindowsUIButton, x => x.Close());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.SaveAndClose());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], x => x.Close(), "Cancel");
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], x => x.Delete(), "Delete");
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[4], x => x.Refresh(), "Refresh");

            fluentAPI.SetBinding(customerNameSimpleLabelItem, l => l.Text, x => x.Title);
        }
    }
}