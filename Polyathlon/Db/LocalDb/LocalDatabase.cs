using System.Collections;
using Newtonsoft.Json.Linq;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Net.Http.Headers;
using Polyathlon.Db.Common;
using Polyathlon.Models.Common;
namespace Polyathlon.Db.LocalDb;


/// <summary>
/// The base class for unit of works that provides the storage for repositories. 
/// </summary>
//public class LocalDbBase
//{
//    readonly Dictionary<string, object> tables = new();

//    protected IList GetLocalViewTable<TEntity>(string request)           
//        where TEntity : class
//    {
//        object? result = null;
//        if (!tables.TryGetValue(request, out result))
//        {
//            string content = @"{'total_rows':4,'offset':0,'rows':[
//                { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'Москва'} },
//                { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'Рязань'} }
//            ]}";

//            JObject jModules = JObject.Parse(content);

//            IList<JToken> rows = jModules["rows"].Children().ToList();

//            List<TEntity> Entities = new(rows.Count);

//            foreach (JToken row in rows)
//            {
//                TEntity Entity = row["doc"].ToObject<TEntity>();
//                Entities.Add(Entity);
//            }
//            tables[request] = result;
//        }
//        return (IList?)result;
//    }      
//}

/// <summary>
/// The base class for unit of works that provides the storage for repositories. 
/// </summary>
public sealed class LocalDatabase {
    private static volatile LocalDatabase localDb;

    private Lazy<PerBaseUrlFlurlClientFactory> flurlClientFactory = new Lazy<PerBaseUrlFlurlClientFactory>();

    private static object SyncRoot = new();

    private static readonly Dictionary<string, object> tables = new();
    
    //private static readonly Dictionary<string, object> viewTables = new();

    private LocalDatabase() { }

    public static LocalDatabase LocalDb {
        get {
            if (localDb == null) {
                lock (SyncRoot) {
                    if (localDb == null)
                        localDb = new LocalDatabase();
                }
            }
            return localDb;
        }
    }

    private string GetContent(Flurl.Url url) {       
        string content = string.Empty;
        //IFlurlClientFactory? flurlClientFactory = new PerBaseUrlFlurlClientFactory();
        
        //string origin = @$"{url.Root}/{url.PathSegments[0]}";
        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .SetQueryParam(url.Query)
            .WithBasicAuth(Settings.Settings.Data.settingsDB.UserName, Settings.Settings.Data.settingsDB.Password)
            .AllowAnyHttpStatus();
        try {
            var response = flurlRequest.GetAsync();// JsonAsync();
            var responseBody = response.Result.ResponseMessage;
            content = responseBody.Content.ReadAsStringAsync().Result;
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
        return content;
    }

    private async ValueTask<string> CheckEntityContent(Flurl.Url url) {
        string content = string.Empty;
        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)            
            .WithBasicAuth(Settings.Settings.Data.settingsDB.UserName, Settings.Settings.Data.settingsDB.Password)
            .AllowAnyHttpStatus();
        
        var response = await flurlRequest.HeadAsync();
        if (!response.IsSuccessful())
            throw new ConnectException(response.ResponseMessage.ReasonPhrase ?? "Unknown error");            
        return response.ResponseMessage.Headers?.ETag?.Tag ?? "";
    }

    private string SaveEntityContent(Flurl.Url url) {
        string content = string.Empty;
        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            //.SetQueryParam(url.Query)
            .WithBasicAuth(Settings.Settings.Data.settingsDB.UserName, Settings.Settings.Data.settingsDB.Password)            
            .AllowAnyHttpStatus();
        try {
            //var response = flurlRequest.PutJsonAsync(new {
            //    name = "Республик Адыгея3",
            //    code = 2,
            //    shortName = "Рес. Адыгея"
            //}
            //var response = flurlRequest.PutStringAsync( @"{
            //    'name': 'Республик Адыгея3',
            //    'code': '2',
            //    'shortName': 'Рес. Адыгея'
            //}"
            
            var response = flurlRequest.PostJsonAsync(new {
                _id = "my:SpaghettiWithMeatballs",
                name = "1111",
                age = "2222"
            }); 

            
            //response.Wait();
            var responseBody = response.Result.ResponseMessage;

            content = responseBody.Content.ReadAsStringAsync().Result;
            HttpResponseHeaders headers = responseBody.Headers;
            string result = headers?.ETag?.Tag ?? "";
            System.Diagnostics.Debug.WriteLine(result);
            return result;
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
        return "11";
    }

    private string ChangeEntityContent(Flurl.Url url) {
        string content = string.Empty;
        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .SetQueryParam(url.Query)
            .WithBasicAuth(Settings.Settings.Data.settingsDB.UserName, Settings.Settings.Data.settingsDB.Password)
            .AllowAnyHttpStatus();
        try {
            //var response = flurlRequest.PutJsonAsync(new {
            //    name = "Республик Адыгея3",
            //    code = 2,
            //    shortName = "Рес. Адыгея"
            //}
            //var response = flurlRequest.PutStringAsync( @"{
            //    'name': 'Республик Адыгея3',
            //    'code': '2',
            //    'shortName': 'Рес. Адыгея'
            //}"

            //var response = flurlRequest.PostJsonAsync(new {                
            //    name = "3333",
            //    age = "4444"
            //});

            var response = flurlRequest.PutJsonAsync(new {
                name = "3333",
                age = "4444"
            });

            //response.Wait();
            var responseBody = response.Result.ResponseMessage;

            content = responseBody.Content.ReadAsStringAsync().Result;
            HttpResponseHeaders headers = responseBody.Headers;
            string result = headers?.ETag?.Tag ?? "";
            System.Diagnostics.Debug.WriteLine(result);
            return result;
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
        return "11";
    }

    private string DeleteEntityContent(Flurl.Url url) {
        string content = string.Empty;
        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .SetQueryParam(url.Query)
            .WithBasicAuth(Settings.Settings.Data.settingsDB.UserName, Settings.Settings.Data.settingsDB.Password)
            .AllowAnyHttpStatus();
        try {
            //var response = flurlRequest.PutJsonAsync(new {
            //    name = "Республик Адыгея3",
            //    code = 2,
            //    shortName = "Рес. Адыгея"
            //}
            //var response = flurlRequest.PutStringAsync( @"{
            //    'name': 'Республик Адыгея3',
            //    'code': '2',
            //    'shortName': 'Рес. Адыгея'
            //}"

            //var response = flurlRequest.PostJsonAsync(new {                
            //    name = "3333",
            //    age = "4444"
            //});

            //var response = flurlRequest.PutJsonAsync(new {
            //    name = "3333",
            //    age = "4444"
            //});

            var response = flurlRequest.DeleteAsync();

            //response.Wait();
            var responseBody = response.Result.ResponseMessage;

            content = responseBody.Content.ReadAsStringAsync().Result;
            HttpResponseHeaders headers = responseBody.Headers;
            string result = headers?.ETag?.Tag ?? "";
            System.Diagnostics.Debug.WriteLine(result);
            return result;
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
        return "11";
    }

    //public TEntity CreateEntity<TEntity>(string request) 
    //    where TEntity : EntityBase {
    //    object? result = null;
    //    string content = GetContent(request);

    //    JObject jModules = JObject.Parse(content);
    //    IList<JToken> rows = jModules["rows"].Children().ToList();

    //    TEntity entity = row["doc"].ToObject<TEntity>();

    //    return entity;
    //}

    public void GetEntity<TEntity>(string request)
        where TEntity : EntityBase {
        Url url = "http://base.rsu.edu.ru:5984/polyathlon/region:3a1c079241b4d051b71e77e78c024b3a";
        
        //string content = CheckEntityContent(url);

        //JObject jModules = JObject.Parse(content);
        //IList<JToken> rows = jModules["rows"].Children().ToList();

        //TEntity entity = row["doc"].ToObject<TEntity>();

        //return new();
    }

    public async Task<bool> CheckEntity<TViewEntity>(TViewEntity viewEntity)        
        where TViewEntity : ViewEntityBase<EntityBase> {
        ///<summary>
        /// URL request should be like this: "http://base.rsu.edu.ru:5984/polyathlon/region:3a1c079241b4d051b71e77e78c024b3a";
        ///</summary>
        Url url = $@"{viewEntity.Url.Origin()}/{viewEntity.Id}";
        return await CheckEntityContent(url) != $@"""{viewEntity.Rev}""";
    }

    public async Task SaveEntity<TViewEntity>(TViewEntity viewEntity)
        where TViewEntity : ViewEntityBase<EntityBase> {
        //Url url = "http://base.rsu.edu.ru:5984/polyathlon/region:3a1c079241b4d051b71e77e78c024b3a?rev=3-9dc8f4fb36133da152bd1a525af3c4ee";
        //Url url = "http://base.rsu.edu.ru:5984/polyathlon/my:SpaghettiWithMeatballs?rev=2-b474070511544efa35e9719fe109724f"; //
        //Url url = "http://base.rsu.edu.ru:5984/polyathlon/my:ant";
        //Url url = "http://base.rsu.edu.ru:5984/polyathlon/my:SpaghettiWithMeatballs?rev=2-b474070511544efa35e9719fe109724f";
        //Url url = "http://base.rsu.edu.ru:5984/polyathlon/region:3a1c079241b4d051b71e77e78c024b3a1";
        //string content = DeleteEntityContent(url);
        //string content = CheckEntityContent(url);
        if (!await CheckEntity<TViewEntity>(viewEntity))
            throw new DbException("Конфликт ревизий");
    }

    public IDictionary GetLocalDbTable<TEntity, TViewEntity>(string request, Func<TEntity, Url, TViewEntity> createViewEntity)
       where TEntity : EntityBase {
        object? result = null;
        if (!tables.TryGetValue(request, out result)) {            
            lock (SyncRoot) {
                if (!tables.TryGetValue(request, out result)) {
                    //string content = @"{'total_rows':4,'offset':0,'rows':[
                    //        { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'Москва', 'shortName': 'М'} },
                    //        { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'Рязанская область', 'shortName': 'Ряз. обл.'} }
                    //    ]}";
                                      
                    string content = GetContent(request);
                    Url origin = new Url(request);
                    //string content = ServerConnection.Connection.Request(request);

                    JObject jModules = JObject.Parse(content);
                    IList<JToken> rows = jModules["rows"].Children().ToList();

                    //Dictionary<string, TEntity> Entities = new Dictionary<string, TEntity>(rows.Count);
                    Dictionary<string, TViewEntity> ViewEntities = new Dictionary<string, TViewEntity>(rows.Count);

                    foreach (JToken row in rows) {
                        TEntity entity = row["doc"].ToObject<TEntity>();
                        //Entities.TryAdd(entity.Id, entity);
                        ViewEntities[entity.Id] = createViewEntity(entity, origin);
                    }
                    tables[request] = result = ViewEntities;                    
                }
            }
        }
        return (IDictionary?)result;
    }
}
