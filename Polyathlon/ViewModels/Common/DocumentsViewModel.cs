using System.ComponentModel;
using System.Collections.ObjectModel;

using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;

namespace Polyathlon.ViewModels.Common
{
    /// <summary>
    /// The base class for POCO view models that operate the collection of documents.
    /// </summary>
    /// <typeparam name="TModule">A navigation list entry type.</typeparam>
    public abstract class DocumentsViewModel<TModule>
        : ISupportLogicalLayout
        where TModule : ModuleViewEntity
    {
        private const string ViewLayoutName = "DocumentViewModel";

        /// <summary>
        /// Initializes a new instance of the DocumentsViewModel class.
        /// </summary>
        protected DocumentsViewModel()
        {
            Modules = CreateModules();
            foreach (var module in Modules)
                Messenger.Default.Register<NavigateMessage<TModule>>(this, module, x => Show(x.Token));
            Messenger.Default.Register<DestroyOrphanedDocumentsMessage>(this, x => DestroyOrphanedDocuments());
        }

        private void DestroyOrphanedDocuments()
        {
            var orphans = this.GetOrphanedDocuments().Except(this.GetImmediateChildren());
            foreach (IDocument orphan in orphans)
            {
                orphan.DestroyOnClose = true;
                orphan.Close();
            }
        }

        /// <summary>
        /// Navigation list that represents a collection of module descriptions.
        /// </summary>
        public ObservableCollection<TModule> Modules { get; private set; }

        /// <summary>
        /// A currently selected navigation list entry. This property is writable. When this property is assigned a new value, it triggers the navigating to the corresponding document.
        /// Since DocumentsViewModel is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        /// </summary>
        public virtual TModule SelectedModule { get; set; }

        /// <summary>
        /// A navigation list entry that corresponds to the currently active document. If the active document does not have the corresponding entry in the navigation list, the property value is null. This property is read-only.
        /// Since DocumentsViewModel is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        /// </summary>
        public virtual TModule ActiveModule { get; protected set; }

        /// <summary>
        /// Saves changes in all opened documents.
        /// Since DocumentsViewModel is a POCO view model, an instance of this class will also expose the SaveAllCommand property that can be used as a binding source in views.
        /// </summary>
        public void SaveAll()
        {
            Messenger.Default.Send(new SaveAllMessage());
        }

        /// <summary>
        /// Used to close all opened documents and allows you to save unsaved results and to cancel closing.
        /// Since DocumentsViewModel is a POCO view model, an instance of this class will also expose the OnClosingCommand property that can be used as a binding source in views.
        /// </summary>
        /// <param name="cancelEventArgs">An argument of the System.ComponentModel.CancelEventArgs type which is used to cancel closing if needed.</param>
        public virtual void OnClosing(CancelEventArgs cancelEventArgs)
        {
            SaveLogicalLayout();
            if (LayoutSerializationService != null)
            {
                PersistentLayoutHelper.PersistentViewsLayout[ViewLayoutName] = LayoutSerializationService.Serialize();
            }
            Messenger.Default.Send(new CloseAllMessage(cancelEventArgs));
            PersistentLayoutHelper.SaveLayout();
        }

        /// <summary>
        /// Contains a current state of the navigation pane.
        /// </summary>
        /// Since DocumentsViewModel is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        public virtual NavigationPaneVisibility NavigationPaneVisibility { get; set; }

        /// <summary>
        /// Navigates to a document.
        /// Since DocumentsViewModel is a POCO view model, an instance of this class will also expose the ShowCommand property that can be used as a binding source in views.
        /// </summary>
        /// <param name="module">A navigation list entry specifying a document what to be opened.</param>
        public void Show(TModule module)
        {
            IDocument? document = ShowCore(module);
            documentChanging = true;
            ActiveModule = module;
            documentChanging = false;
            DocumentShown(module, document);
        }

        protected virtual void DocumentShown(TModule module, IDocument? document)
        {
        }

        public IDocument? ShowCore(TModule module)
        {
            if (module == null || DocumentManagerService == null)
                return null;
            IDocument document = DocumentManagerService.FindDocumentByIdOrCreate(module.ViewType, x => CreateDocument(module));
            document.Show();
            return document;
        }

        /// <summary>
        /// Creates and shows a document which view is bound to PeekCollectionViewModel. The document is created and shown using a document manager service named "WorkspaceDocumentManagerService".
        /// Since DocumentsViewModel is a POCO view model, an instance of this class will also expose the PinPeekCollectionViewCommand property that can be used as a binding source in views.
        /// </summary>
        /// <param name="module">A navigation list entry that is used as a PeekCollectionViewModel factory.</param>
        public void PinPeekCollectionView(TModule module)
        {
            if (WorkspaceDocumentManagerService == null)
                return;
            IDocument document = WorkspaceDocumentManagerService.FindDocumentByIdOrCreate(module.ViewType, x => CreatePinnedPeekCollectionDocument(module));
            document.Show();
        }

        /// <summary>
        /// Finalizes the DocumentsViewModel initialization and opens the default document.
        /// Since DocumentsViewModel is a POCO view model, an instance of this class will also expose the OnLoadedCommand property that can be used as a binding source in views.
        /// </summary>
        public virtual void OnLoaded(TModule module)
        {
            IsLoaded = true;
            Show(module);
        }

        private bool documentChanging = false;

        private void OnActiveDocumentChanged(object sender, ActiveDocumentChangedEventArgs e)
        {
        }

        protected IDocumentManagerService DocumentManagerService
        { get { return this.GetService<IDocumentManagerService>(); } }

        protected ILayoutSerializationService LayoutSerializationService
        { get { return this.GetService<ILayoutSerializationService>(); } }

        protected IDocumentManagerService WorkspaceDocumentManagerService
        { get { return this.GetService<IDocumentManagerService>("WorkspaceDocumentManagerService"); } }

        public virtual TModule DefaultModule
        { get { return Modules.First(); } }

        protected bool IsLoaded { get; private set; }

        protected virtual void OnSelectedModuleChanged(TModule oldModule)
        {
            if (IsLoaded && !documentChanging)
            {
                Show(SelectedModule);
            }
        }

        protected virtual void OnActiveModuleChanged(TModule oldModule)
        {
            SelectedModule = ActiveModule;
        }

        private IDocument CreateDocument(TModule module)
        {
            var document = DocumentManagerService.CreateDocument(module.ViewType, module, this);

            document.Title = GetModuleTitle(module);
            document.DestroyOnClose = false;

            return document;
        }

        protected virtual string GetModuleTitle(TModule module)
        {
            return module.Title ?? string.Empty;
        }

        private IDocument CreatePinnedPeekCollectionDocument(TModule module)
        {
            var document = WorkspaceDocumentManagerService.CreateDocument("PeekCollectionView", module.Name);

            document.Title = module.Title;

            return document;
        }

        protected abstract ObservableCollection<TModule> CreateModules();

        public void SaveLogicalLayout()
        {
            PersistentLayoutHelper.PersistentLogicalLayout = this.SerializeDocumentManagerService();
        }

        public bool RestoreLogicalLayout()
        {
            if (string.IsNullOrEmpty(PersistentLayoutHelper.PersistentLogicalLayout))
            {
                return false;
            }

            this.RestoreDocumentManagerService(PersistentLayoutHelper.PersistentLogicalLayout);

            return true;
        }

        bool ISupportLogicalLayout.CanSerialize
        {
            get { return true; }
        }

        IDocumentManagerService ISupportLogicalLayout.DocumentManagerService
        {
            get { return DocumentManagerService; }
        }

        IEnumerable<object>? ISupportLogicalLayout.LookupViewModels
        {
            get { return null; }
        }
    }

    /// <summary>
    /// Represents a navigation pane state.
    /// </summary>
    public enum NavigationPaneVisibility
    {
        /// <summary>
        /// Navigation pane is visible and minimized.
        /// </summary>
        Minimized,

        /// <summary>
        /// Navigation pane is visible and not minimized.
        /// </summary>
        Normal,

        /// <summary>
        /// Navigation pane is invisible.
        /// </summary>
        Off
    }
}