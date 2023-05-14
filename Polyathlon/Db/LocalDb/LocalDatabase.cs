using System.Collections;

using Newtonsoft.Json.Linq;

using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

using Polyathlon.Db.Common;
using Polyathlon.Models.Common;
using Polyathlon.Properties;

namespace Polyathlon.Db.LocalDb;

public sealed class LocalDatabase
{
    private static volatile LocalDatabase localDb;

    private Lazy<PerBaseUrlFlurlClientFactory> flurlClientFactory = new();

    private static object syncRoot = new();

    private static readonly Dictionary<string, object> tables = new();

    private LocalDatabase()
    {
    }

    public static LocalDatabase LocalDb
    {
        get
        {
            if (localDb == null)
            {
                lock (syncRoot)
                {
                    localDb ??= new LocalDatabase();
                }
            }

            return localDb;
        }
    }

    private async ValueTask<IFlurlResponse?> CheckEntityResponse(Url url)
    {
        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .WithBasicAuth(ConnectionSettings.Default.UserName,
                           ConnectionSettings.Default.Password)
            .AllowAnyHttpStatus();

        var response = await flurlRequest.HeadAsync().ConfigureAwait(false);

        if (!response.IsSuccessful())
        {
            throw new ConnectException(response.ResponseMessage.ReasonPhrase ?? "Unknown error");
        }

        return response;
    }

    public async ValueTask<bool> CheckEntityAsync<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase
    {
        Url url = $@"{viewEntity.Request.Origin()}/{viewEntity.Id}";

        var response = await CheckEntityResponse(url).ConfigureAwait(false);

        return response?.ResponseMessage.Headers?.ETag?.Tag.Trim('"') == viewEntity.Rev;
    }

    public async ValueTask<IFlurlResponse?> SaveEntityResponse<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase
    {
        Url url = $@"{viewEntity.Request.Origin()}/{viewEntity.Id}";

        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .WithBasicAuth(ConnectionSettings.Default.UserName,
                           ConnectionSettings.Default.Password)
            .AllowAnyHttpStatus();

        var response = await flurlRequest.PutJsonAsync(viewEntity.Entity).ConfigureAwait(false);

        if (!response.IsSuccessful())
        {
            throw new ConnectException(response.ResponseMessage.ReasonPhrase ?? "Unknown error");
        }

        return response;
    }

    public async Task SaveEntityAsync<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TEntity : EntityBase
        where TViewEntity : ViewEntityBase<TEntity>
    {
        if (!await CheckEntityAsync<TViewEntity, TEntity>(viewEntity).ConfigureAwait(false))
        {
            throw new DbException("Conflict of revisions");
        }

        var response = await SaveEntityResponse<TViewEntity, TEntity>(viewEntity).ConfigureAwait(false);
        viewEntity.Rev = response?.ResponseMessage.Headers?.ETag?.Tag.Trim('"');
    }

    public async ValueTask<IFlurlResponse?> DeleteEntityResponseAsync<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase
    {
        Url url = $@"{viewEntity.Request.Origin()}/{viewEntity.Id}";

        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .SetQueryParam("rev", viewEntity.Rev)
            .WithBasicAuth(ConnectionSettings.Default.UserName,
                           ConnectionSettings.Default.Password)
            .AllowAnyHttpStatus();

        var response = await flurlRequest.DeleteAsync().ConfigureAwait(false);

        if (!response.IsSuccessful())
        {
            throw new ConnectException(
                response.ResponseMessage.Content.ReadAsStringAsync().Result ?? "Unknown error");
        }

        return response;
    }

    public async Task DeleteEntityAsync<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TEntity : EntityBase
        where TViewEntity : ViewEntityBase<TEntity>
    {
        await DeleteEntityResponseAsync<TViewEntity, TEntity>(viewEntity).ConfigureAwait(false);
    }

    public async ValueTask<IFlurlResponse?> GetEntityResponseAsync<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase
    {
        Url url = $@"{viewEntity.Request.Origin()}/{viewEntity.Id}";

        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .WithBasicAuth(ConnectionSettings.Default.UserName,
                           ConnectionSettings.Default.Password)
            .AllowAnyHttpStatus();

        var response = await flurlRequest.GetAsync().ConfigureAwait(false);

        if (!response.IsSuccessful())
        {
            throw new ConnectException(
                response.ResponseMessage.Content.ReadAsStringAsync().Result ?? "Unknown error");
        }

        return response;
    }

    public async Task<TEntity?> GetEntityAsync<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TEntity : EntityBase
        where TViewEntity : ViewEntityBase<TEntity>
    {
        var response = await GetEntityResponseAsync<TViewEntity, TEntity>(viewEntity).ConfigureAwait(false);
        if (viewEntity.Rev != response?.ResponseMessage.Headers?.ETag?.Tag.Trim('"'))
        {
            string content = response.ResponseMessage.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntity>(content);
        }

        return null;
    }

    public async ValueTask<IFlurlResponse?> SaveNewEntityResponse<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase
    {
        Url url = $@"{viewEntity.Request.Origin()}";

        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .WithBasicAuth(ConnectionSettings.Default.UserName,
                           ConnectionSettings.Default.Password)
            .AllowAnyHttpStatus();

        var response = await flurlRequest.PostJsonAsync(viewEntity.Entity).ConfigureAwait(false);

        if (!response.IsSuccessful())
        {
            throw new ConnectException(
                response.ResponseMessage.Content.ReadAsStringAsync().Result ?? "Unknown error");
        }

        return response;
    }

    public async Task SaveNewEntityAsync<TViewEntity, TEntity>(TViewEntity viewEntity)
        where TEntity : EntityBase
        where TViewEntity : ViewEntityBase<TEntity>
    {
        var response = await SaveNewEntityResponse<TViewEntity, TEntity>(viewEntity).ConfigureAwait(false);
        viewEntity.Rev = response?.ResponseMessage.Headers?.ETag?.Tag.Trim('"');
    }

    private string GetContent(Url url)
    {
        string content = string.Empty;

        IFlurlClient flurlClient = flurlClientFactory.Value.Get(url.Root);
        IFlurlRequest flurlRequest = flurlClient.Request()
            .AppendPathSegments(url.PathSegments)
            .SetQueryParam(url.Query)
            .WithBasicAuth(ConnectionSettings.Default.UserName,
                           ConnectionSettings.Default.Password)
            .AllowAnyHttpStatus();

        try
        {
            var response = flurlRequest.GetAsync();
            var responseBody = response.Result.ResponseMessage;
            content = responseBody.Content.ReadAsStringAsync().Result;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }

        return content;
    }

    public IDictionary GetLocalDbTable<TEntity, TViewEntity>(string request, Func<TEntity, Url, TViewEntity> createViewEntity)
        where TEntity : EntityBase
    {
        if (!tables.TryGetValue(request, out object? result))
        {
            lock (syncRoot)
            {
                if (!tables.TryGetValue(request, out result))
                {
                    string content = GetContent(request);
                    Url origin = new(request);

                    JObject jModules = JObject.Parse(content);
                    IList<JToken> rows = jModules["rows"].Children().ToList();

                    Dictionary<string, TViewEntity> ViewEntities = new(rows.Count);

                    foreach (JToken row in rows)
                    {
                        TEntity entity = row["doc"].ToObject<TEntity>();
                        ViewEntities[entity.Id] = createViewEntity(entity, origin);
                    }
                    tables[request] = result = ViewEntities;
                }
            }
        }

        return (IDictionary?)result;
    }
}