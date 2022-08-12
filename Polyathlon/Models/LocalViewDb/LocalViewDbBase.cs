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

    public ObservableCollection<TViewEntity> GetLocalViewCollection<TEntity, TViewEntity>(ModuleViewEntity moduleDescription, Func<TEntity, TViewEntity> createViewEntity)
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
                    ObservableCollection<TViewEntity> ViewEntities = new ObservableCollection<TViewEntity>();
                    foreach (var request in moduleDescription.Requests) {

                        IDictionary EntitiesDb = LocalDbBase.LocalDb.GetLocalDbTable<TEntity>(request.Url);
                        if (EntitiesDb is not null) {
                            foreach (DictionaryEntry item in EntitiesDb) {
                                TEntity entity = (TEntity)item.Value;
                                ViewEntities.Add(createViewEntity(entity));
                            }
                        }
                    }
                    tables[requests] = result = ViewEntities;
                }
            }
        }
        return (ObservableCollection<TViewEntity>)result;
    }

    public ObservableCollection<TViewEntity> GetModuleViewCollection<TEntity, TViewEntity>(Url request, Func<TEntity, string, TViewEntity> createViewEntity)
        where TEntity : EntityBase 
        where TViewEntity : ViewEntityBase<TEntity> { 
        object? result;        
        if (!tables.TryGetValue(request.Origin(), out result)) {
            lock (SyncRoot) {
                if (!tables.TryGetValue(request.Origin(), out result)) {
                    ObservableCollection<TViewEntity> ViewEntities = new ObservableCollection<TViewEntity>();
                    IDictionary EntitiesDb = LocalDbBase.LocalDb.GetLocalDbTable<TEntity>(request);
                    if (EntitiesDb is not null) {
                        foreach (DictionaryEntry item in EntitiesDb) {
                            TEntity entity = (TEntity)item.Value;                            
                            ViewEntities.Add(createViewEntity(entity, request.Origin()));
                        }
                    }                    
                    tables[request] = result = ViewEntities;
                }
            }
        }
        return (ObservableCollection<TViewEntity>)result;
    }

}
