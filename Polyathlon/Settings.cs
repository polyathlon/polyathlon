using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyathlon
{
    internal class SettingsDB
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string Port { get; set; }
        public string Host => $"http://{HostName}:{Port}";

        public SettingsDB()
        {
            UserName = Properties.Settings.Default.UserName;
            Password = Properties.Settings.Default.Password;
            HostName = Properties.Settings.Default.HostName;
            Port = Properties.Settings.Default.Port;
        }
    }

    internal class Settings
    {
        private static readonly Settings settings = new();
        public static Settings Data
        {
            get
            {
                return settings;
            }
        }

        public SettingsDB settingsDB;

        private Settings()
        {
            settingsDB = new();
        }
    }
}
