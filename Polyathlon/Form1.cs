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
            using Forms.DatabaseSettingsForm databaseSettingsForm = new();

            databaseSettingsForm.ShowDialog();
        }
    }
}