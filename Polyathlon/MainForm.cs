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
    }
}