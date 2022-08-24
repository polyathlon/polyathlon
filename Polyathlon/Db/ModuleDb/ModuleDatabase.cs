using System.Collections;
using Flurl;
using Polyathlon.Db.Common;
using Polyathlon.Db.LocalDb;
using Polyathlon.Models.Common;
using Polyathlon.Models.Entities;

namespace Polyathlon.Db.ModuleDb;


/// <summary>
/// The base class for unit of works that provides the storage for repositories. 
/// </summary>
public sealed class ModuleDatabase {
    private static volatile ModuleDatabase moduleDb;

    private static object SyncRoot = new Object();

    private static readonly Dictionary<string, object> tables = new();

    private ModuleDatabase() { }

    public static ModuleDatabase ModuleDb {
        get {
            if (moduleDb == null) {
                lock (SyncRoot) {
                    if (moduleDb == null)
                        moduleDb = new ModuleDatabase();
                }
            }
            return moduleDb;
        }
    }

    public IDictionary<string, TViewEntity>  GetModuleViewCollection<TEntity, TViewEntity>(ModuleViewEntity moduleDescription, Func<TEntity, Flurl.Url, TViewEntity> createViewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase {
        object? result = null;
        if (!tables.TryGetValue(moduleDescription.Id, out result)) {
            lock (SyncRoot) {
                if (!tables.TryGetValue(moduleDescription.Id, out result)) {
                    Dictionary<string, TViewEntity> ViewEntities = new();
                    foreach (var request in moduleDescription.Requests) {
                        IDictionary Entities = LocalDatabase.LocalDb.GetLocalDbTable<TEntity, TViewEntity>(request.Url, createViewEntity);
                        if (Entities is not null) {                            
                            foreach (DictionaryEntry item in Entities) {
                                TViewEntity entity = (TViewEntity)item.Value;
                                ViewEntities[entity.Id] = entity;
                            }
                        }
                    }
                    tables[moduleDescription.Id] = result = ViewEntities;
                }
            }
        }
        return (Dictionary<string, TViewEntity>)result;
    }

    public IDictionary<string, TViewEntity> GetModuleViewCollection<TEntity, TViewEntity>(Url request, Func<TEntity, Url, TViewEntity> createViewEntity)
        where TEntity : EntityBase 
        where TViewEntity : ViewEntityBase<TEntity> { 
        object? result;
        if (!tables.TryGetValue(request.Origin(), out result)) {
            lock (SyncRoot) {
                if (!tables.TryGetValue(request.Origin(), out result)) {    
                    IDictionary ViewEntities = LocalDatabase.LocalDb.GetLocalDbTable<TEntity, TViewEntity>(request, createViewEntity);    
                    tables[request.Origin()] = result = ViewEntities;
                }
            }
        }
        return result as Dictionary<string, TViewEntity>;
    }

}
