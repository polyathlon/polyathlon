using System.Collections;
using Newtonsoft.Json.Linq;

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

        static public IList LocalViewTable<TViewEntity, TEntity>(string request)
            where TEntity : class
            where TViewEntity : class, new()            
        {
            object? result = null;
            if (!tables.TryGetValue(request, out result))
            {
                IList EntitiesDb = LocalDbBase.GetLocalDbTable<TEntity>(request);
                IList ViewEntities = new List<TViewEntity>();                
                if (EntitiesDb is not null)
                {
                    foreach (var item in EntitiesDb)
                    {
                        ViewEntities.Add(new TViewEntity());
                    }
                }                
                tables[request] = result;
            }
            return (IList?)result;
        }        
    }
}
