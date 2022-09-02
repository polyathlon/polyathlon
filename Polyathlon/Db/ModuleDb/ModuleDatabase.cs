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

    private static object SyncRoot => new();

    private static readonly Dictionary<string, object> syncRoots = new(); 

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

    public IDictionary<string, TViewEntity> GetModuleViewCollection<TEntity, TViewEntity>(ModuleViewEntity moduleDescription, Func<TEntity, Flurl.Url, TViewEntity> createViewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase {
        object? result = null;
        if (!tables.TryGetValue(moduleDescription.Id, out result)) {
            lock (SyncRoot) {
                if (!syncRoots.ContainsKey(moduleDescription.Id)) {
                    syncRoots[moduleDescription.Id] = new();
                }
            }
            if (Monitor.TryEnter(syncRoots[moduleDescription.Id])) {
                try {
                    if (!tables.TryGetValue(moduleDescription.Id, out result)) {
                        //foreach (var dependency in moduleDescription.Dependencies) {
                        //    var modules = tables[moduleDescription.Request] as Dictionary<string, ModuleViewEntity>;
                        //    var module = modules?[dependency.Module] ?? null;
                        //    if (module.Id == "module:01GA69CF93RKFMC2EA07EZ4YHY")
                        //        GetModuleViewCollection<Region, RegionView>(module,)
                        //}

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
                finally {
                    Monitor.TryEnter(syncRoots[moduleDescription.Id]);
                }
            }
            else {
                return null;
            }
        }
        return (Dictionary<string, TViewEntity>)result;
    }

    public TViewEntity GetViewEntities<TViewEntity>(String moduleId, String entityId) {
        return ((Dictionary<string, TViewEntity>)tables[moduleId])[entityId];
    }
    //public IDictionary<string, TViewEntity> GetModuleViewCollection<TEntity, TViewEntity>(ModuleViewEntity moduleDescription, Func<TEntity, Flurl.Url, TViewEntity> createViewEntity)
    //    where TViewEntity : ViewEntityBase<TEntity>
    //    where TEntity : EntityBase {
    //    object? result = null;
    //    if (!tables.TryGetValue(moduleDescription.Id, out result)) {
    //        lock (SyncRoot) {
    //            if (!tables.TryGetValue(moduleDescription.Id, out result)) {
    //                Dictionary<string, TViewEntity> ViewEntities = new();
    //                foreach (var request in moduleDescription.Requests) {
    //                    IDictionary Entities = LocalDatabase.LocalDb.GetLocalDbTable<TEntity, TViewEntity>(request.Url, createViewEntity);
    //                    if (Entities is not null) {
    //                        foreach (DictionaryEntry item in Entities) {
    //                            TViewEntity entity = (TViewEntity)item.Value;
    //                            ViewEntities[entity.Id] = entity;
    //                        }
    //                    }
    //                }
    //                tables[moduleDescription.Id] = result = ViewEntities;
    //            }
    //        }
    //    }
    //    return (Dictionary<string, TViewEntity>)result;
    //}

    //public IDictionary<string, TViewEntity> CreateModuleDependency<TEntity, TViewEntity>(ModuleViewEntity moduleDescription)
    //    where TViewEntity : ViewEntityBase<TEntity>
    //    where TEntity : EntityBase {
    //    object? result = null;
    //    if (!tables.TryGetValue(moduleDescription.Id, out result)) {
    //        foreach (var request in moduleDescription.Requests) {
    //            GetModuleViewCollection<TEntity, TViewEntity>
    //        }
    //        lock (SyncRoot) {
    //            if (!tables.TryGetValue(moduleDescription.Id, out result)) {
    //                Dictionary<string, TViewEntity> ViewEntities = new();
    //                foreach (var request in moduleDescription.Requests) {
    //                    IDictionary Entities = LocalDatabase.LocalDb.GetLocalDbTable<TEntity, TViewEntity>(request.Url, createViewEntity);
    //                    if (Entities is not null) {
    //                        foreach (DictionaryEntry item in Entities) {
    //                            TViewEntity entity = (TViewEntity)item.Value;
    //                            ViewEntities[entity.Id] = entity;
    //                        }
    //                    }
    //                }
    //                tables[moduleDescription.Id] = result = ViewEntities;
    //            }
    //        }
    //    }
    //    return (Dictionary<string, TViewEntity>)result;
    //}

    public IDictionary<string, TViewEntity> GetModuleViewCollection<TEntity, TViewEntity>(Url request, Func<TEntity, Url, TViewEntity> createViewEntity)
        where TEntity : EntityBase 
        where TViewEntity : ViewEntityBase<TEntity> { 
        object? result;
        if (!tables.TryGetValue(request, out result)) {
            lock (SyncRoot) {
                if (!tables.TryGetValue(request, out result)) {    
                    IDictionary ViewEntities = LocalDatabase.LocalDb.GetLocalDbTable<TEntity, TViewEntity>(request, createViewEntity);
                    tables[request] = result = ViewEntities;
                }
            }
        }
        return result as Dictionary<string, TViewEntity>;
    }

}
