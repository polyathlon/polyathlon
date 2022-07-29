using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Collections;
using Newtonsoft.Json.Linq;
using Flurl.Http;
using Flurl.Http.Configuration;

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
public sealed class LocalDbBase
{
    private static volatile LocalDbBase localDb;

    private static object SyncRoot = new();

    private static readonly Dictionary<string, object> tables = new();

    private LocalDbBase() { }

    public static LocalDbBase LocalDb
    {
        get
        {
            if (localDb == null)
            {
                lock (SyncRoot)
                {
                    if (localDb == null)
                        localDb = new LocalDbBase();
                }
            }
            return localDb;
        }
    }

    public IList GetLocalDbTable<TEntity>(string request)
       where TEntity : class
    {
        object? result = null;
        if (!tables.TryGetValue(request, out result))
        {
            lock (SyncRoot)
            {
                if (!tables.TryGetValue(request, out result))
                {
                    /*string content = @"{'total_rows':4,'offset':0,'rows':[
                            { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'Москва', 'shortName': 'М'} },
                            { 'id':'module:8997d7edcad3eae911a0c9abb100097a','key':'module:8997d7edcad3eae911a0c9abb100097a','value':{ 'rev':'1-52dc66bc4a76166e8348d4b76e2b4b78'},'doc':{ '_id':'module:8997d7edcad3eae911a0c9abb100097a','_rev':'1-52dc66bc4a76166e8348d4b76e2b4b78','name':'Рязанская область', 'shortName': 'Ряз. обл.'} }
                        ]}";*/
                    
                    // Start: Get content
                    string content = string.Empty;
                    IFlurlClientFactory? flurlClientFactory = new PerBaseUrlFlurlClientFactory();
                    IFlurlClient flurlClient = flurlClientFactory.Get(Settings.Settings.Data.settingsDB.Host);
                    IFlurlRequest flurlRequest = flurlClient.Request()
                        .AppendPathSegments("test-requests-regions", "_all_docs")
                        .SetQueryParam("include_docs", "true")
                        .WithBasicAuth(Settings.Settings.Data.settingsDB.UserName, Settings.Settings.Data.settingsDB.Password)
                        .AllowAnyHttpStatus();
                    try
                    {
                        var response = flurlRequest.GetAsync();// JsonAsync();
                        var responseBody = response.Result.ResponseMessage;
                        content = responseBody.Content.ReadAsStringAsync().Result;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                    // End: Get content

                    JObject jModules = JObject.Parse(content);

                    IList<JToken> rows = jModules["rows"].Children().ToList();

                    IList<TEntity> Entities = new List<TEntity>(rows.Count);

                    foreach (JToken row in rows)
                    {
                        TEntity Entity = row["doc"].ToObject<TEntity>();
                        Entities.Add(Entity);
                    }
                    tables[request] = result = Entities;
                }                        
            }                
        }
        return (IList?)result;
    }
}
