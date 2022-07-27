using System.Collections;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;


namespace Polyathlon.DataModel
{
    /// <summary>
    /// The base class for unit of works that provides the storage for repositories. 
    /// </summary>
    public sealed class LocalViewDbBase
    {
        private static volatile LocalViewDbBase localViewDb;

        private static object looker = new Object();

        private static readonly Dictionary<string, object> tables = new();
                
        private LocalViewDbBase() { }

        public static LocalViewDbBase LocalViewDb
        {
            get
            {
                if (localViewDb == null)
                {
                    lock (looker)
                    {
                        if (localViewDb == null)
                            localViewDb = new LocalViewDbBase();
                    }
                }
                return localViewDb;
            }
        }

        static public ObservableCollection<TViewEntity> GetLocalViewTable<TViewEntity, TEntity>(string request, Func<TEntity, TViewEntity> createViewEntity)
            where TEntity : class
            where TViewEntity : class, new()            
        {
            object? result = null;
            if (!tables.TryGetValue(request, out result))
            {                
                IList EntitiesDb = LocalDbBase.GetLocalDbTable<TEntity>(request);
                ObservableCollection<TViewEntity> ViewEntities = new ObservableCollection<TViewEntity>();
                if (EntitiesDb is not null)
                {
                    foreach (var item in EntitiesDb)
                    {   
                        ViewEntities.Add(createViewEntity((TEntity)item));
                    }
                }                
                tables[request] = result = ViewEntities;
            }
            return (ObservableCollection<TViewEntity>) result;
        }        
    }
}
