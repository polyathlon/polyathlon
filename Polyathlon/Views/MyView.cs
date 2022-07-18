using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM.UI;

namespace Polyathlon.Views
{
    [ViewType("MyView")]
    public partial class MyView : DevExpress.XtraEditors.XtraUserControl
    {
        public MyView()
        {
            InitializeComponent();
        }
    }
}
