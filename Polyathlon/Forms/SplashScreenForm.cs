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


namespace Polyathlon.Forms
{
    public partial class SplashScreenForm : DevExpress.XtraEditors.XtraForm
    {
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.Timer timer;

        private void SplashScreenForm_Shown(object sender, EventArgs e)
        {

            timer = new System.Windows.Forms.Timer();

            progressBarControl.Position = 0;

            timer.Interval = 300;

            

            timer.Start();

            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (progressBarControl.Position < 100)
            {
                progressBarControl.Position += 10;
            }
            else
            {
                timer.Stop();
                progressBarControl.Position += 10;
                timer.Stop();
                this.Hide();
            }
        }
    }
}