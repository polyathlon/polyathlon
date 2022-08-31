
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace Polyathlon.DataModel;

/// <summary>
/// The base class for unit of works that provides the storage for repositories. 
/// </summary>
//public sealed class ServerConnection
//{
//    private static volatile ServerConnection serverConnection;

//    private static object SyncRoot = new();    

//    private readonly IFlurlClientFactory flurlClientFactory;

//    private ServerConnection() {
//        flurlClientFactory = new PerBaseUrlFlurlClientFactory();
//    }

//    public static ServerConnection Connection
//    {
//        get
//        {
//            if (serverConnection == null)
//            {
//                lock (SyncRoot)
//                {
//                    if (serverConnection == null)
//                        serverConnection = new();
//                }
//            }
//            return serverConnection;
//        }
//    }

//    public string Request(string request)       
//    {
//        Url? url = new(request);        
//        IFlurlClient flurlClient = flurlClientFactory.Get(url.Root);
//        IFlurlRequest flurlRequest = flurlClient.Request()
//            .AppendPathSegments(url.Path)
//            .SetQueryParams(url.QueryParams)
//            .WithBasicAuth(ConnectionSettings.Default.UserName, ConnectionSettings.Default.Password)
//            .AllowAnyHttpStatus();
//        try
//        {
//            var response = flurlRequest.GetAsync();
//            var responseBody = response.Result.ResponseMessage;
//            return responseBody.Content.ReadAsStringAsync().Result;
//        }
//        catch (Exception ex)
//        {
//            System.Diagnostics.Debug.WriteLine(ex.ToString());
//            return ex.Message;
//        }          
//    }
//}
