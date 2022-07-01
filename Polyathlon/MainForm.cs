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

namespace Polyathlon
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            using Forms.SplashScreenForm splashScreenForm = new();
            splashScreenForm.ShowDialog();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using Forms.DatabaseSettingsForm databaseSettingsForm = new();
            databaseSettingsForm.ShowDialog();            
        }
    }
}