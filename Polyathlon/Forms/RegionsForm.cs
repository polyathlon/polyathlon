//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using CouchDB.Driver;
//using CouchDB.Driver.Options;

namespace Polyathlon.Forms
{
    public partial class RegionsForm : Form
    {
        public RegionsForm()
        {
            InitializeComponent();
        }

        private async void CreateDBButton_Click(object sender, EventArgs e)
        {
            // Получение сервера по Host, используя базовую аутентификацию
            await using var client = new CouchClient(Settings.Data.settingsDB.Host, builder => builder
                .UseBasicAuthentication(Settings.Data.settingsDB.UserName,
                                        Settings.Data.settingsDB.Password));

            try
            {
                // Получение или создание БД regions
                var regions = client.GetOrCreateDatabaseAsync<Entities.Region>().Result;

                var content = regions.ToArray();
                if (content.Length == 0)
                {
                    // Создание документов в БД regions, если их нет
                    foreach (var name in Entities.Region.Regions)
                    {
                        await regions.AddAsync(new Entities.Region(name, name));
                    }

                    MessageBox.Show("БД создана");
                }
                else
                {
                    MessageBox.Show("БД уже существует");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void OutputRegionsButton_Click(object sender, EventArgs e)
        {
            // Получение сервера по Host, используя базовую аутентификацию
            await using var client = new CouchClient(Settings.Data.settingsDB.Host, builder => builder
                .UseBasicAuthentication(Settings.Data.settingsDB.UserName,
                                        Settings.Data.settingsDB.Password));

            try
            {
                // Получение БД regions
                var regions = client.GetDatabase<Entities.Region>();

                // Получение коллекции документов
                var content = regions.ToArray();
                if (content.Length == 0)
                {
                    MessageBox.Show("Документов нет");
                }
                else
                {
                    gridControl1.DataSource = content;
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
