using System.Collections;

using Flurl;

using Polyathlon.Db.LocalDb;
using Polyathlon.Models.Common;
using Polyathlon.Models.Entities;

namespace Polyathlon.Db.ModuleDb;

public sealed class ModuleDatabase
{
    private static volatile ModuleDatabase moduleDb;

    private static object syncRoot => new();

    private static readonly Dictionary<string, object> syncRoots = new();

    private static readonly Dictionary<string, object> tables = new();

    private ModuleDatabase()
    {
    }

    public static ModuleDatabase ModuleDb
    {
        get
        {
            if (moduleDb == null)
            {
                lock (syncRoot)
                {
                    moduleDb ??= new ModuleDatabase();
                }
            }

            return moduleDb;
        }
    }

    public IDictionary<string, TViewEntity>?
        GetModuleViewCollection<TEntity, TViewEntity>(ModuleViewEntity moduleViewEntity,
                                                      Func<TEntity, Url, TViewEntity> createViewEntity)
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase
    {
        if (!tables.TryGetValue(moduleViewEntity.Id, out object? result))
        {
            lock (syncRoot)
            {
                if (!syncRoots.ContainsKey(moduleViewEntity.Id))
                {
                    syncRoots[moduleViewEntity.Id] = new();
                }
            }

            if (!Monitor.TryEnter(syncRoots[moduleViewEntity.Id]))
            {
                return null;
            }

            try
            {
                if (!tables.TryGetValue(moduleViewEntity.Id, out result))
                {
                    Dictionary<string, TViewEntity> viewEntities = new();
                    foreach (var request in moduleViewEntity.Requests)
                    {
                        IDictionary entities = LocalDatabase.LocalDb.GetLocalDbTable(request.Url, createViewEntity);
                        if (entities is not null)
                        {
                            foreach (DictionaryEntry item in entities)
                            {
                                TViewEntity entity = (TViewEntity)item.Value;
                                viewEntities[entity.Id] = entity;
                            }
                        }
                    }
                    tables[moduleViewEntity.Id] = result = viewEntities;
                }
            }
            finally
            {
                Monitor.TryEnter(syncRoots[moduleViewEntity.Id]);
            }
        }

        return result as Dictionary<string, TViewEntity>;
    }

    public TViewEntity GetViewEntities<TViewEntity>(string moduleId, string entityId)
    {
        return ((Dictionary<string, TViewEntity>)tables[moduleId])[entityId];
    }

    public IDictionary<string, TViewEntity>
        GetModuleViewCollection<TEntity, TViewEntity>(Url request, Func<TEntity, Url, TViewEntity> createViewEntity)
        where TEntity : EntityBase
        where TViewEntity : ViewEntityBase<TEntity>
    {
        if (!tables.TryGetValue(request, out object? result))
        {
            lock (syncRoot)
            {
                if (!tables.TryGetValue(request, out result))
                {
                    IDictionary ViewEntities = LocalDatabase.LocalDb.GetLocalDbTable<TEntity, TViewEntity>(request, createViewEntity);
                    tables[request] = result = ViewEntities;
                }
            }
        }

        return result as Dictionary<string, TViewEntity>;
    }
}