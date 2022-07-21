using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System.Drawing;

namespace Polyathlon.Views {
    public partial class BaseViewWithWinUIButtons : XtraUserControl {
        public BaseViewWithWinUIButtons() {
            InitializeComponent();
        }
        Size peekFormSizeDefault = new Size(200, 260);

        void windowsUIButtonPanel_QueryPeekFormContent(object sender, QueryPeekFormContentEventArgs e) {
            if (e.Button.Properties.Tag != null && e.Button.Properties.Tag is Control) 
                e.Control = e.Button.Properties.Tag as Control;
        }
        void windowsUIButtonPanel_ButtonClick(object sender, ButtonEventArgs e) {
            if (e.Button.Properties.Tag != null) 
                windowsUIButtonPanel.ShowPeekForm(e.Button);
        }
        protected override void ScaleControl(System.Drawing.SizeF factor, BoundsSpecified specified) {
            base.ScaleControl(factor, specified);
            Size peekFormSizeActual = new Size((int)(peekFormSizeDefault.Width * factor.Width),
                (int)(peekFormSizeDefault.Height * factor.Height));
            windowsUIButtonPanel.PeekFormSize = peekFormSizeActual;
        }
    }
}
