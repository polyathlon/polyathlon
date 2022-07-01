//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Polyathlon.Forms
{
    public partial class DatabaseSettingsForm : Form
    {
        public DatabaseSettingsForm()
        {
            InitializeComponent();
        }

        private void DatabaseSettingsForm_Load(object sender, EventArgs e)
        {
            outputUserNameTextBox.Text = Settings.Settings.Data.settingsDB.UserName;
            outputPasswordTextBox.Text = Settings.Settings.Data.settingsDB.Password;
            outputHostNameTextBox.Text = Settings.Settings.Data.settingsDB.HostName;
            outputPortTextBox.Text = Settings.Settings.Data.settingsDB.Port;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings.Settings.Data.settingsDB.UserName = outputUserNameTextBox.Text;
            Settings.Settings.Data.settingsDB.Password = outputPasswordTextBox.Text;
            Settings.Settings.Data.settingsDB.HostName = outputHostNameTextBox.Text;
            Settings.Settings.Data.settingsDB.Port = outputPortTextBox.Text;

            Properties.Settings.Default.UserName = outputUserNameTextBox.Text;
            Properties.Settings.Default.Password = outputPasswordTextBox.Text;
            Properties.Settings.Default.HostName = outputHostNameTextBox.Text;
            Properties.Settings.Default.Port = outputPortTextBox.Text;

            Properties.Settings.Default.Save();
        }
    }
}
