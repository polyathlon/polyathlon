using DevExpress.Mvvm;

namespace Polyathlon.ViewModels.Common
{
    /// <summary>
    /// Provides the extension methods that are used to implement the IDocumentManagerService interface.
    /// </summary>
    public static class DocumentManagerServiceExtensions
    {
        /// <summary>
        /// Creates and shows a document containing a single object view model for the existing entity.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to create and show the document.</param>
        /// <param name="parentViewModel">An object that is passed to the view model of the created view.</param>
        /// <param name="primaryKey">An entity primary key.</param>
        public static IDocument ShowExistingEntityDocument<TEntity, TViewEntity, TPrimaryKey>(this IDocumentManagerService documentManagerService, object parentViewModel, TPrimaryKey primaryKey)
        {
            IDocument document = FindEntityDocument<TEntity, TViewEntity, TPrimaryKey>(documentManagerService, primaryKey) ?? CreateDocument<TEntity>(documentManagerService, primaryKey, parentViewModel);
            if (document != null)
                document.Show();
            return document;
        }

        public static IDocument ShowMyExistingEntityDocument<TEntity, TViewEntity>(this IDocumentManagerService documentManagerService, object parameter, object parentViewModel)
        {
            //IDocument document = FindEntityDocument<TEntity, TViewEntity>(documentManagerService, primaryKey) ?? CreateDocument<TEntity>(documentManagerService, primaryKey, parentViewModel);
            IDocument document = CreateDocument<TEntity>(documentManagerService, parameter, parentViewModel);
            if (document != null)
                document.Show();
            return document;
        }

        /// <summary>
        /// Creates and shows a document containing a single object view model for new entity.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to create and show the document.</param>
        /// <param name="parentViewModel">An object that is passed to the view model of the created view.</param>
        /// <param name="newEntityInitializer">An optional parameter that provides a function that initializes a new entity.</param>
        public static void ShowNewEntityDocument<TEntity>(this IDocumentManagerService documentManagerService, object parentViewModel, Action<TEntity> newEntityInitializer = null) 
        {
            IDocument document = FindNewEntityDocument<TEntity>(documentManagerService) ?? CreateDocument<TEntity>(documentManagerService, newEntityInitializer ?? (x => DefaultEntityInitializer(x)), parentViewModel);
            if(document != null)
                document.Show();
        }

        /// <summary>
        /// Creates and shows a document containing a single object view model for new entity.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to create and show the document.</param>
        /// <param name="parentViewModel">An object that is passed to the view model of the created view.</param>
        /// <param name="newEntityInitializer">An optional parameter that provides a function that initializes a new entity.</param>
        public static void MyShowNewEntityDocument<TEntity>(this IDocumentManagerService documentManagerService, object parameter, object parentViewModel) {
            IDocument document = CreateDocument<TEntity>(documentManagerService, parameter, parentViewModel);
            if (document != null)
                document.Show();
        }

        /// <summary>
        /// Searches for a document that contains a single object view model editing entity with a specified primary key.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to find a document.</param>
        /// <param name="primaryKey">An entity primary key.</param>
        public static IDocument FindEntityDocument<TEntity, TViewEntity, TPrimaryKey>(this IDocumentManagerService documentManagerService, TPrimaryKey primaryKey)
        {
            if (documentManagerService == null)
                return null;
            foreach (IDocument document in documentManagerService.Documents)
            {
                ISingleObjectViewModel<TViewEntity> entityViewModel = document.Content as ISingleObjectViewModel<TViewEntity>;
                //if (entityViewModel != null && object.Equals(entityViewModel.PrimaryKey, primaryKey))
                  //  return document;
            }
            return null;
        }

        //public static IDocument FindEntityDocument<TEntity, TViewEntity, TPrimaryKey>(this IDocumentManagerService documentManagerService, TPrimaryKey primaryKey)
        //{
        //    if (documentManagerService == null)
        //        return null;
        //    foreach (IDocument document in documentManagerService.Documents)
        //    {
        //        ISingleObjectViewModel<TEntity, TViewEntity, TPrimaryKey> entityViewModel = document.Content as ISingleObjectViewModel<TEntity, TViewEntity, TPrimaryKey>;
        //        if (entityViewModel != null && object.Equals(entityViewModel.PrimaryKey, primaryKey))
        //            return document;
        //    }
        //    return null;
        //}
        /// <summary>
        /// Searches for a document that contains a single object view model editing a new entity.
        /// </summary>
        /// <param name="documentManagerService">An instance of the IDocumentManager interface used to find a document.</param>
        /// <param name="primaryKey">An entity primary key.</param>
        public static IDocument FindNewEntityDocument<TEntity>(this IDocumentManagerService documentManagerService) {
            if(documentManagerService == null)
                return null;
            foreach(IDocument document in documentManagerService.Documents) 
            {
                ISingleObjectViewModel<TEntity> entityViewModel = document.Content as ISingleObjectViewModel<TEntity>;
                if (entityViewModel != null && entityViewModel.IsNew())
                    return document;
            }
            return null;
        }

        static void DefaultEntityInitializer<TEntity>(TEntity entity) { }

        static IDocument CreateDocument<TEntity>(IDocumentManagerService documentManagerService, object parameter, object parentViewModel)
        {
            if (documentManagerService == null)
                return null;
            var document = documentManagerService.CreateDocument(GetDocumentTypeName<TEntity>(), parameter, parentViewModel);
            document.Id = "_" + Guid.NewGuid().ToString().Replace('-', '_');
            document.DestroyOnClose = false;
            return document;
        }

        public static string GetDocumentTypeName<TEntity>()
        {
            return typeof(TEntity).Name + "View";
        }
    }
}
