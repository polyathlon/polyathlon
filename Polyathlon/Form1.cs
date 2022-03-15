using Polyathlon.Forms;

namespace Polyathlon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using DatabaseSettingsForm databaseSettingsForm = new();

            databaseSettingsForm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using RegionsForm regionsForm = new();

            regionsForm.ShowDialog();
        }
    }
}