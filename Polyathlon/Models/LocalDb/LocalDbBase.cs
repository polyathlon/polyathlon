using System.Collections;
using Newtonsoft.Json.Linq;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

using Polyathlon.DataModel.Common;

namespace Polyathlon.DataModel;

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
//                { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'������'} },
//                { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'������'} }
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
public sealed class LocalDbBase {
    private static volatile LocalDbBase localDb;

    private Lazy<PerBaseUrlFlurlClientFactory> flurlClientFactory = new Lazy<PerBaseUrlFlurlClientFactory>();

    private static object SyncRoot = new();

    private static readonly Dictionary<string, object> tables = new();

    private LocalDbBase() { }

    public static LocalDbBase LocalDb {
        get {
            if (localDb == null) {
                lock (SyncRoot) {
                    if (localDb == null)
                        localDb = new LocalDbBase();
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

    public IDictionary GetLocalDbTable<TEntity>(Url request)
       where TEntity : EntityBase {
        object? result = null;
        if (!tables.TryGetValue(request.Origin(), out result)) {            
            lock (SyncRoot) {
                if (!tables.TryGetValue(request.Origin(), out result)) {
                    //string content = @"{'total_rows':4,'offset':0,'rows':[
                    //        { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'������', 'shortName': '�'} },
                    //        { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'��������� �������', 'shortName': '���. ���.'} }
                    //    ]}";
                                      
                    string content = GetContent(request);
                    //string content = ServerConnection.Connection.Request(request);

                    JObject jModules = JObject.Parse(content);
                    IList<JToken> rows = jModules["rows"].Children().ToList();

                    Dictionary<string, TEntity> Entities = new Dictionary<string, TEntity>(rows.Count);

                    foreach (JToken row in rows) {
                        TEntity Entity = row["doc"].ToObject<TEntity>();
                        Entities.TryAdd(Entity.Id, Entity);
                    }
                    tables[request.Origin()] = result = Entities;
                }
            }
        }
        return (IDictionary?)result;
    }
}