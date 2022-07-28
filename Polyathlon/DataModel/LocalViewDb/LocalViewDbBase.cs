using System.Collections;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.DataModel;

/// <summary>
/// The base class for unit of works that provides the storage for repositories. 
/// </summary>
public sealed class LocalViewDbBase
{
    private static volatile LocalViewDbBase localViewDb;

    private static object SyncRoot = new Object();

    private static readonly Dictionary<string, object> tables = new();
            
    private LocalViewDbBase() { }

    public static LocalViewDbBase LocalViewDb
    {
        get
        {
            if (localViewDb == null)
            {
                lock (SyncRoot)
                {
                    if (localViewDb == null)
                        localViewDb = new LocalViewDbBase();
                }
            }
            return localViewDb;
        }
    }

    public ObservableCollection<TViewEntity> GetLocalViewCollection<TViewEntity, TEntity>(PolyathlonModuleDescription moduleDescription, Func<TEntity, TViewEntity> createViewEntity)
        where TEntity : class
        where TViewEntity : class, new()            
    {
        object? result = null;
        string requests = "";
        foreach (var item in moduleDescription.Requests)
        {
            if (item.Url is not null)
                requests.Concat(item.Url);
        }                 
        if (!tables.TryGetValue(requests, out result))
        {
            lock (SyncRoot)
            {
                if (!tables.TryGetValue(requests, out result))
                {
                    ObservableCollection<TViewEntity> ViewEntities = new ObservableCollection<TViewEntity>();
                    foreach (var request in moduleDescription.Requests)
                    {

                        IList EntitiesDb = LocalDbBase.LocalDb.GetLocalDbTable<TEntity>(request.Url);
                        if (EntitiesDb is not null)
                        {
                            foreach (var item in EntitiesDb)
                            {
                                ViewEntities.Add(createViewEntity((TEntity)item));
                            }
                        }
                    }
                    tables[requests] = result = ViewEntities;
                }
            }
        }
        return (ObservableCollection<TViewEntity>) result;
    }        
}
