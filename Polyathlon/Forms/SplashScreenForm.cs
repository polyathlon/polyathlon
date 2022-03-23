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



            timer.Interval = 3000;

            //starts the timer

            timer.Start();

            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)

        {

            //after 3 sec stop the timer

            timer.Stop();

            //display mainform

            this.Hide();

        }
    }
}