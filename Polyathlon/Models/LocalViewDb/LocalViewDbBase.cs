using System.Collections;
using System.Collections.ObjectModel;
using Flurl;
using Polyathlon.DataModel.Common;
using Polyathlon.DataModel.Entities;

namespace Polyathlon.DataModel;

/// <summary>
/// The base class for unit of works that provides the storage for repositories. 
/// </summary>
public sealed class LocalViewDbBase {
    private static volatile LocalViewDbBase localViewDb;

    private static object SyncRoot = new Object();

    private static readonly Dictionary<string, object> tables = new();

    private LocalViewDbBase() { }

    public static LocalViewDbBase LocalViewDb {
        get {
            if (localViewDb == null) {
                lock (SyncRoot) {
                    if (localViewDb == null)
                        localViewDb = new LocalViewDbBase();
                }
            }
            return localViewDb;
        }
    }

    public IDictionary<string, TViewEntity>  GetLocalViewCollection<TEntity, TViewEntity>(ModuleViewEntity moduleDescription, Func<TEntity, Flurl.Url, TViewEntity> createViewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase {
        object? result = null;
        string requests = "";
        foreach (var item in moduleDescription.Requests) {
            if (item.Url is not null)
                requests.Concat(item.Url);
        }
        if (!tables.TryGetValue(requests, out result)) {
            lock (SyncRoot) {
                if (!tables.TryGetValue(requests, out result)) {
                    Dictionary<string, TViewEntity> ViewEntities = new();
                    foreach (var request in moduleDescription.Requests) {
                        IDictionary Entities = LocalDbBase.LocalDb.GetLocalDbTable<TEntity>(request.Url);
                        if (Entities is not null) {
                            Url origin = ((Url)request.Url).Origin();
                            foreach (DictionaryEntry item in Entities) {
                                TEntity entity = (TEntity)item.Value;
                                ViewEntities[entity.Id] = createViewEntity(entity, origin);                                
                            }
                        }
                    }
                    tables[requests] = result = ViewEntities;
                }
            }
        }
        return (Dictionary<string, TViewEntity>)result;
    }

    public IDictionary<Url, TViewEntity> GetModuleViewCollection<TEntity, TViewEntity>(Url request, Func<TEntity, string, TViewEntity> createViewEntity)
        where TEntity : EntityBase 
        where TViewEntity : ViewEntityBase<TEntity> { 
        object? result;
        Url origin = request.Origin();
        if (!tables.TryGetValue(origin, out result)) {
            lock (SyncRoot) {
                if (!tables.TryGetValue(origin, out result)) {
                    Dictionary<string, TViewEntity>  ViewEntities = new();
                    IDictionary Entities = LocalDbBase.LocalDb.GetLocalDbTable<TEntity>(request);
                    if (Entities is not null) {
                        foreach (DictionaryEntry item in Entities) {
                            TEntity entity = item.Value as TEntity;
                            ViewEntities[entity.Id] = createViewEntity(entity, origin);
                        }
                    }
                    tables[request] = result = ViewEntities;
                }
            }
        }
        return result as Dictionary<Url, TViewEntity>;
    }

}
