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
using System.Linq;
using System.Threading.Tasks;
using CouchDB.Driver.Extensions;
using CouchDB.Driver.Options;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.Utils.MVVM.Services;
using Polyathlon.DataModel;
using Polyathlon.ViewModels;
using CSharp.Ulid;
using Polyathlon.Views;

using DevExpress.Utils.MVVM;
//using DevExpress.Utils.Taskbar;
//using DevExpress.Utils.Taskbar.Core;
using DevExpress.XtraBars.Navigation;
using Polyathlon.Helpers;


//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polyathlon
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            using Forms.SplashScreenForm splashScreenForm = new();
            splashScreenForm.ShowDialog();
            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
                InitializeNavigation();
        }

        void InitializeNavigation()
        {
            mvvmContext.RegisterService(DocumentManagerService.Create(navigationFrame));
            mvvmContext.RegisterService("FilterDialogService", DevExpress.Utils.MVVM.Services.DialogService.CreateFlyoutDialogService(this));

            //ModuleModel moduleModel1 = new ModuleModel() { Id = "11", Rev = "112", Group = "222", Title = "1", TileColor = Color.FromArgb(255, 254, 253), ViewDocumentType = "1" };
            //string json = JsonConvert.SerializeObject(moduleModel1);
            //Debug.WriteLine(json);
            //ModuleModel moduleModel2 = JsonConvert.DeserializeObject<ModuleModel>(json);

            //string modules = @"{""total_rows"":4,""offset"":0,""rows"":[
            //    { ""id"":""module:8997d7edcad3eae911a0c9abb100097a"",""key"":""module:8997d7edcad3eae911a0c9abb100097a"",""value"":{ ""rev"":""1-52dc66bc4a76166e8348d4b76e2b4b78""},""doc"":{ ""_id"":""module:8997d7edcad3eae911a0c9abb100097a"",""_rev"":""1-52dc66bc4a76166e8348d4b76e2b4b78"",""title"":""Мой просмотр"",""group"":""Operation"",""ViewDocumentType"":""MyView""} },
            //    { ""id"":""module:8997d7edcad3eae911a0c9abb1002c9a"",""key"":""module:8997d7edcad3eae911a0c9abb1002c9a"",""value"":{ ""rev"":""2-f95dbc40cbfc2d4f619df957835df54e""},""doc"":{ ""_id"":""module:8997d7edcad3eae911a0c9abb1002c9a"",""_rev"":""2-f95dbc40cbfc2d4f619df957835df54e"",""title"":""Мой просмотр"",""group"":""Operation"",""ViewDocumentType"":""MyView""} },
            //    { ""id"":""module:8997d7edcad3eae911a0c9abb1006720"",""key"":""module:8997d7edcad3eae911a0c9abb1006720"",""value"":{ ""rev"":""2-2f60825a429913c4900c1b1d331eb217""},""doc"":{ ""_id"":""module:8997d7edcad3eae911a0c9abb1006720"",""_rev"":""2-2f60825a429913c4900c1b1d331eb217"",""name"":""Владислав""} },
            //    { ""id"":""module:8997d7edcad3eae911a0c9abb100a34b"",""key"":""module:8997d7edcad3eae911a0c9abb100a34b"",""value"":{ ""rev"":""2-7582e5ecd3bdc143cc19789f6856cd5c""},""doc"":{ ""_id"":""module:8997d7edcad3eae911a0c9abb100a34b"",""_rev"":""2-7582e5ecd3bdc143cc19789f6856cd5c"",""name"":""Ektyf""} }
            //    ]}";

            //JObject rss = JObject.Parse(modules);

            //IList<JToken> rows = rss["rows"].Children().ToList();

            //foreach(JToken row in rows)
            //{
            //    ModuleModel moduleModel = row["doc"].ToObject<ModuleModel>();
                
            //    Debug.WriteLine(moduleModel.Id);
            //    //SearchResult searchResult = result.ToObject<SearchResult>();
            //    //searchResults.Add(searchResult);
            //}
            ////   textBox1.Text = responseBody.Content.ReadAsStringAsync().Result;
            ////JObject rss = rss["rows"];// . JObject.Parse(output);
            //textBox1.Text = rss["rows"].ToString();// responseBody.Content.ReadAsStringAsync().Result;


            var fluentAPI = mvvmContext.OfType<PolyathlonViewModel>();
            //fluentAPI.ViewModel.Modules = fluentAPI.ViewModel.Modules.Append(new PolyathlonModuleDescription(documentType: moduleModel1.ViewDocumentType, group: moduleModel1.Group, title: moduleModel1.Title)).ToArray();
            fluentAPI.SetItemsSourceBinding(tileBar,
                tb => tb.Groups, x => x.ModuleGroups,
                (group, moduleGroup) => object.Equals(group.Tag, moduleGroup),
                moduleGroup => CreateGroup(fluentAPI, moduleGroup)
            );
            //fluentAPI.WithEvent(this, "Load")
            //    .EventToCommand(x => x.OnLoaded(null), x => x.DefaultModule);
            //fluentAPI.WithEvent(this, "Closing")
            //    .EventToCommand(x => x.OnClosing(null));

            //fluentAPI.BindCommand(navButtonInfo, x => x.Info());
            //fluentAPI.BindCommand(navButtonHelp, x => x.About());
            //fluentAPI.BindCommand(navButtonClose, x => x.Exit());

            //tileBar.SelectedItem = GetItem(fluentAPI.ViewModel.DefaultModule);
        }

        TileBarGroup CreateGroup(MVVMContextFluentAPI<PolyathlonViewModel> fluentAPI, IGrouping<string, PolyathlonModuleDescription> moduleGroup)
        {
            TileBarGroup group = new TileBarGroup() { Tag = moduleGroup };
            group.Text = moduleGroup.Key.ToUpper();
            foreach (PolyathlonModuleDescription module in moduleGroup)
                group.Items.Add(RegisterModuleItem(fluentAPI, module));
            return group;
        }

        TileBarItem RegisterModuleItem(MVVMContextFluentAPI<PolyathlonViewModel> fluentAPI, PolyathlonModuleDescription module)
        {
            TileBarItem item = new TileBarItem() { Tag = module };
            item.Text = module.ModuleTitle;
            tileBarItem2.Elements[0].ImageUri = "hybriddemo_dashboard;Svg";
            item.Elements[0].ImageUri = MenuExtensions.GetImageUri(module.ModuleTitle);
            item.AppearanceItem.Normal.BackColor = module.TileColor;//TileColorConverter.GetBackColor(module);
            item.ItemSize = TileBarItemSize.Wide;
            //if (module.FilterViewModel != null)
            //{
            //    item.ShowDropDownButton = (module.FilterViewModel.CustomFilters.Count() > 0) ? Utils.DefaultBoolean.True : Utils.DefaultBoolean.False;
            //    item.DropDownControl = CreateFiltersContainer(module.FilterViewModel);
            //    item.DropDownOptions.BackColorMode = BackColorMode.UseTileBackColor;
            //}
            fluentAPI.BindCommand(item, x => x.Show(null), x => module);
            return item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using Forms.DatabaseSettingsForm databaseSettingsForm = new();
            databaseSettingsForm.ShowDialog();            
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            await using var context = new MyCouchDBContext();
            var Rebels = await context.Rebels.Where(r => r.Name == "Владислав").ToListAsync();
        }
        class myClass
        {
            public string? Status { get; set; }
            public object? Seeds { get; set; }
        }

        private async void button3_Click(object sender, EventArgs e)
        {            
            couchServer1.UserName = Settings.Settings.Data.settingsDB.UserName;
            couchServer1.Password = Settings.Settings.Data.settingsDB.Password;
            textBox1.Text = couchServer1.Uri.ToString();
            IFlurlClientFactory? flurlClientFactory = new PerBaseUrlFlurlClientFactory();
            IFlurlClient flurlClient = flurlClientFactory.Get("http://localhost:5984");
            //IFlurlRequest flurlRequest = flurlClient.Request().AppendPathSegments("polyathlon", "_all_docs").AppendPathSegment("_all_docs")
            IFlurlRequest flurlRequest = flurlClient.Request().AppendPathSegments("my-base","_partition", "part", "_all_docs")//.AppendPathSegment("_all_docs")
                .WithBasicAuth("admin", "admin")
                .AllowAnyHttpStatus();
            try
            {
                var response = await flurlRequest.GetAsync();// JsonAsync();
                var responseBody = response.ResponseMessage;
                var output = responseBody.Content.ReadAsStringAsync().Result;
                JObject rss = JObject.Parse(output);
                //   textBox1.Text = responseBody.Content.ReadAsStringAsync().Result;
                //JObject rss = rss["rows"];// . JObject.Parse(output);
                textBox1.Text = rss["rows"].ToString();// responseBody.Content.ReadAsStringAsync().Result;
                
                //var myClass = JsonConvert.DeserializeObject<myClass>(output);
                dynamic results = JsonConvert.DeserializeObject<dynamic>(output);
                //results
                //JObject googleSearch = JObject.Parse(googleSearchText);
                //textBox1.Text = myClass.Status;
                textBox1.Text = results.rows;
                //if (response is { StatusCode: (int)HttpStatusCode.OK })
                {
                    //var result = await Task.FromResult(response).ReceiveString();
                }
                
                //textBox1.Text = response.ToString();
            }
            catch (Exception ex)
            {                
                Debug.WriteLine(ex.ToString());
            }
            


            //= new FlurlClientFactory();
            //PerBaseUrlFlurlClientFactory
            //IFlurlClient flurlClient = new FlurlClient();
            //IFlurlClient flurlClient = new FlurlClient();
            //IFlurlRequest flurlRequest = flurlClient.Request(couchServer1.Uri.ToString()).AppendPathSegment("/");
            //IFlurlRequest flurlRequest = flurlClient.Request("http://localhos1:5984/_up")
            //    .WithBasicAuth("admin", "admin")
            //.AllowAnyHttpStatus(HttpStatusCode.NotFound);

            //var response = await flurlRequest.GetStringAsync();

            //if (response is not { StatusCode: (int)HttpStatusCode.OK })
            //{

            //}

            //    //var data = await "http://127.0.0.1:5984/".GetJsonAsync();
                
            //var response = await flurlRequest.GetStringAsync();

            //    .AllowHttpStatus(HttpStatusCode.NotFound)
            //  .GetAsync()
            //                .ConfigureAwait(false);
           // textBox1.Text = response.ToString();
        }

        private void navigationFrame1_Click(object sender, EventArgs e)
        {

        }

        private void tileBar_Click(object sender, EventArgs e)
        {

        }
        #region TileColorConverter
        static class TileColorConverter
        {
            public static Color GetBackColor(PolyathlonModuleDescription module)
            {
                switch (module.DocumentType)
                {
                    case "1":
                        return Color.FromArgb(0x00, 0x87, 0x9C);
                    case "2":
                        return Color.FromArgb(0xCC, 0x6D, 0x00);
                    case "3":
                        return Color.FromArgb(0x40, 0x40, 0x40);
                    case "4":
                        return Color.FromArgb(0x00, 0x73, 0xC4);
                    case "5":
                        return Color.FromArgb(0x40, 0x40, 0x40);
                    case "6":
                        return Color.FromArgb(0x3E, 0x70, 0x38);
                    case "7":
                        return Color.FromArgb(0x40, 0x40, 0x40);
                }
                return Color.FromArgb(0x40, 0x40, 0x40);
            }
        }
        #endregion

        private void navButton2_ElementClick(object sender, NavElementEventArgs e)
        {
             Ulid[] U = new Ulid[100];
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
                U[i] = Ulid.NewUlid();                
            }
            for (int i = 0; i < 100; i++)
            {
                Debug.WriteLine(U[i]);
                
            }
        }
    }
}