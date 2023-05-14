using DevExpress.XtraEditors;

namespace Polyathlon.Forms
{
    public partial class SplashScreenForm : XtraForm
    {
        public SplashScreenForm()
        {
            timer = new System.Windows.Forms.Timer();

            InitializeComponent();
        }

        private System.Windows.Forms.Timer timer;

        private void SplashScreenForm_Shown(object sender, EventArgs e)
        {
            progressBarControl.Position = 0;

            timer.Interval = 300;

            timer.Start();

            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
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

                Hide();
            }
        }
    }
}