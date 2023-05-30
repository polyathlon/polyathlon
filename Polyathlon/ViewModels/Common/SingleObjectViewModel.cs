using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

using CSharp.Ulid;

using Polyathlon.Properties;
using Polyathlon.Models;
using Polyathlon.Db.Common;
using Polyathlon.Db.LocalDb;
using Polyathlon.Models.Common;

namespace Polyathlon.ViewModels.Common
{
    /// <summary>
    /// The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity.
    /// This is a partial class that provides the extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    public abstract class SingleObjectViewModel<TEntity, TViewEntity, TPrimaryKey> : SingleObjectViewModelBase<TEntity, TViewEntity>
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase, new()
    {
        protected SingleObjectViewModel(Func<TEntity, Flurl.Url, TViewEntity> createNewViewEntity)
            : base(createNewViewEntity)
        {
        }
    }

    /// <summary>
    /// The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity.
    /// It is not recommended to inherit directly from this class. Use the SingleObjectViewModel class instead.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    [POCOViewModel]
    public abstract class SingleObjectViewModelBase<TEntity, TViewEntity> : ISingleObjectViewModel<TViewEntity>, ISupportParameter, ISupportParentViewModel, IDocumentContent, ISupportLogicalLayout<string>
        where TViewEntity : ViewEntityBase<TEntity>
        where TEntity : EntityBase, new()
    {
        private object title;

        protected readonly Func<TViewEntity, object> getEntityDisplayNameFunc;

        protected readonly Func<TEntity, Flurl.Url?, TViewEntity> createNewViewEntity;

        private Action<TViewEntity> entityInitializer;

        private bool isEntityNewAndUnmodified;

        private readonly Dictionary<string, IDocumentContent> lookUpViewModels = new();

        /// <summary>
        /// Initializes a new instance of the SingleObjectViewModelBase class.
        /// </summary>
        protected SingleObjectViewModelBase(Func<TEntity, Flurl.Url, TViewEntity> createNewViewEntity)
        {
            this.createNewViewEntity = createNewViewEntity;
            OnInitializeInRuntime();
        }

        /// <summary>
        /// The display text for a given entity used as a title in the corresponding view.
        /// </summary>
        /// <returns></returns>
        public object Title
        { get { return title; } }

        /// <summary>
        /// An entity represented by this view model.
        /// Since SingleObjectViewModelBase is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        /// </summary>
        /// <returns></returns>
        public virtual TViewEntity ViewEntity { get; set; }

        /// <summary>
        /// Updates the Title property value and raises CanExecute changed for relevant commands.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the UpdateCommand property that can be used as a binding source in views.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public void Update()
        {
            isEntityNewAndUnmodified = false;
            UpdateTitle();
            UpdateCommands();
        }

        /// <summary>
        /// Saves changes in the underlying unit of work.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveCommand property that can be used as a binding source in views.
        /// </summary>
        public virtual void Save()
        {
            SaveCore();
        }

        /// <summary>
        /// Determines whether entity has local changes that can be saved.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for SaveCommand.
        /// </summary>
        public virtual bool CanSave()
        {
            return ViewEntity.Entity != OldViewEntity.Entity;
        }

        /// <summary>
        /// Saves changes in the underlying unit of work and closes the corresponding view.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveAndCloseCommand property that can be used as a binding source in views.
        /// </summary>
        [Command(CanExecuteMethodName = "CanSave")]
        public async void SaveAndClose()
        {
            if (await SaveCore())
            {
                this.RaisePropertyChanged(x => x.ViewEntity);
                _ParentViewModel.RaisePropertiesChanged();
                this.Close();
            }
        }

        /// <summary>
        /// Saves changes in the underlying unit of work and create new entity.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveAndNewCommand property that can be used as a binding source in views.
        /// </summary>
        [Command(CanExecuteMethodName = "CanSave")]
        public void SaveAndNew()
        {
            //if (SaveCore())
            //    CreateAndInitializeEntity(this.entityInitializer);
        }

        /// <summary>
        /// Reset entity local changes.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the ResetCommand property that can be used as a binding source in views.
        /// </summary>
        [Display(Name = "Reset Changes")]
        public void Reset()
        {
            MessageResult confirmationResult = MessageBoxService.ShowMessage(CommonResources.Confirmation_Reset, CommonResources.Confirmation_Caption, MessageButton.OKCancel);
            if (confirmationResult == MessageResult.OK)
                Reload();
        }

        /// <summary>
        /// Determines whether entity has local changes.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for ResetCommand.
        /// </summary>
        public bool CanReset()
        {
            return NeedReset();
        }

        private string ViewName
        { get { return typeof(TEntity).Name + "View"; } }

        [DXImage("Save")]
        [Display(Name = "Save Layout")]
        public void SaveLayout()
        {
            PersistentLayoutHelper.TrySerializeLayout(LayoutSerializationService, ViewName);
            PersistentLayoutHelper.SaveLayout();
        }

        [Display(AutoGenerateField = false)]
        public void OnLoaded()
        {
            PersistentLayoutHelper.TryDeserializeLayout(LayoutSerializationService, ViewName);
        }

        /// <summary>
        /// Deletes the entity, save changes and closes the corresponding view if confirmed by a user.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the DeleteCommand property that can be used as a binding source in views.
        /// </summary>
        public virtual async void Delete()
        {
            if (MessageBoxService.ShowMessage(string.Format(CommonResources.Confirmation_Delete, typeof(TEntity).Name), GetConfirmationMessageTitle(), MessageButton.YesNo) != MessageResult.Yes)
                return;

            try
            {
                if (ViewEntity.Rev is not null)
                    await LocalDatabase.LocalDb.DeleteEntityAsync<TViewEntity, TEntity>(ViewEntity);
                _ParentViewModel.RaisePropertiesChanged();
                Close();
            }
            catch (ConnectException e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
            catch (DbException e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
            catch (Exception e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Determines whether the entity can be deleted.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for DeleteCommand.
        /// </summary>
        public virtual bool CanDelete()
        {
            return (ViewEntity is not null) && (ViewEntity.Rev is not null);
        }

        public virtual async void Refresh()
        {
            try
            {
                if (ViewEntity.Rev is null)
                {
                    MessageBoxService.ShowMessage(CommonResources.Entity_Not_Saved_Yet, GetConfirmationMessageTitle(), MessageButton.OK);
                    return;
                }

                TEntity? entityDb = await LocalDatabase.LocalDb.GetEntityAsync<TViewEntity, TEntity>(ViewEntity);
                if (entityDb is null)
                {
                    MessageBoxService.ShowMessage(CommonResources.Entity_Not_Changed, GetConfirmationMessageTitle(), MessageButton.OK);
                    return;
                }

                if (MessageBoxService.ShowMessage(string.Format(CommonResources.Confirmation_Refresh, typeof(TEntity).Name), GetConfirmationMessageTitle(), MessageButton.YesNo) != MessageResult.Yes)
                {
                    return;
                }

                ViewEntity.Entity = entityDb;
                this.RaisePropertyChanged(x => x.ViewEntity);
                OnEntityChanged();
                MessageBoxService.ShowMessage(CommonResources.Entity_Was_Updated, GetConfirmationMessageTitle(), MessageButton.OK);
            }
            catch (ConnectException e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
            catch (DbException e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
            catch (Exception e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
        }

        /// <summary>
        /// Determines whether the entity can be deleted.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for DeleteCommand.
        /// </summary>
        public virtual bool CanRefresh()
        {
            return (ViewEntity is not null) && (ViewEntity.Rev is not null);
        }

        /// <summary>
        /// Closes the corresponding view.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the CloseCommand property that can be used as a binding source in views.
        /// </summary>
        public void Close()
        {
            if (!TryClose())
            {
                return;
            }
            if (DocumentOwner != null)
            {
                DocumentOwner.Close(this);
            }
        }

        protected virtual async ValueTask<bool> SaveCore()
        {
            try
            {
                bool isNewEntity = IsNew();
                OldViewEntity.Entity = ViewEntity.Entity;
                if (ViewEntity.Rev is null)
                    await LocalDatabase.LocalDb.SaveNewEntityAsync<TViewEntity, TEntity>(ViewEntity).ConfigureAwait(false);
                else
                    await LocalDatabase.LocalDb.SaveEntityAsync<TViewEntity, TEntity>(ViewEntity).ConfigureAwait(false);

                return true;
            }
            catch (ConnectException e)
            {
                MessageBoxService.ShowMessage(e.Message, e.Reason, MessageButton.OK, MessageIcon.Error);
            }
            catch (DbException e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
            catch (Exception e)
            {
                MessageBoxService.ShowMessage(e.Message, "Полиатлон", MessageButton.OK, MessageIcon.Error);
            }
            return false;
        }

        protected virtual void OnBeforeEntitySaved(TEntity entity, bool isNewEntity)
        {
        }

        protected virtual void OnEntitySaved(TEntity entity, bool isNewEntity)
        {
        }

        protected virtual void OnBeforeEntityDeleted(TEntity entity)
        {
        }

        protected virtual void OnEntityDeleted(TEntity entity)
        {
        }

        protected virtual void OnInitializeInRuntime()
        {
            Messenger.Default.Register<EntityMessage<TEntity, string>>(this, x => OnEntityMessage(x));
            Messenger.Default.Register<SaveAllMessage>(this, x => Save());
            Messenger.Default.Register<CloseAllMessage>(this, x => OnClosing(x));
        }

        protected virtual void OnEntityMessage(EntityMessage<TEntity, string> message)
        {
            if (ViewEntity == null)
            {
                return;
            }

            if (message.MessageType == EntityMessageType.Deleted && object.Equals(message.PrimaryKey, PrimaryKey))
            {
                Close();
            }
        }

        protected virtual void OnEntityChanged()
        {
            Update();
        }

        protected string PrimaryKey { get; private set; }

        protected IMessageBoxService MessageBoxService
        { get { return this.GetRequiredService<IMessageBoxService>(); } }

        protected ILayoutSerializationService LayoutSerializationService
        { get { return this.GetService<ILayoutSerializationService>(); } }

        protected virtual void OnParameterChanged(object parameter)
        {
            if (parameter is SingleModelAction.New)
            {
                if (_ParentViewModel is CollectionViewModel<TViewEntity, TEntity> parent)
                {
                    var request = parent.ModuleDescription.Requests[0].Url;
                    TEntity entity = new();
                    var idPrefix = string.Empty;
                    if (request?.PathSegments?[1] is not null)
                    {
                        idPrefix = request?.PathSegments?[1] == "_partition" ? request?.PathSegments?[2] : string.Empty;
                    }
                    entity.Id = idPrefix + ":" + Ulid.NewUlid().ToString();
                    ViewEntity = createNewViewEntity(entity, request);
                    OldViewEntity = (TViewEntity)ViewEntity.Clone();
                }
            }
            else if (parameter is ValueTuple<TViewEntity, SingleModelAction> viewParam)
            {
                var (viewEntity, operation) = viewParam;
                if (operation is SingleModelAction.Copy)
                {
                    OldViewEntity = viewEntity;
                    ViewEntity = (TViewEntity)OldViewEntity.Clone();
                }
                else if (operation is SingleModelAction.Edit)
                {
                    OldViewEntity = viewEntity;
                    ViewEntity = (TViewEntity)OldViewEntity.Clone();

                    this.RaisePropertyChanged(m => m.ViewEntity);
                }
            }
        }

        protected void EditEntity(TViewEntity viewEntity)
        {
            ViewEntity = viewEntity;
        }

        protected virtual TViewEntity CreateEntity(TEntity entity)
        {
            return null;
        }

        protected void Reload()
        {
            if (ViewEntity == null || IsNew())
            {
                CreateAndInitializeEntity(entityInitializer);
            }
            else
            {
                LoadEntityByKey(PrimaryKey);
            }
        }

        protected void CreateAndInitializeEntity(Action<TViewEntity> entityInitializer)
        {
            this.entityInitializer = entityInitializer;
            if (_ParentViewModel is CollectionViewModel<TViewEntity, TEntity> parent)
            {
                var request = parent.ModuleDescription.Requests[0].Url;
                TEntity entity = new();
                entity.Id = Ulid.NewUlid().ToString();
                var NewViewEntity = createNewViewEntity(entity, request);
                //if (this.entityInitializer != null)
                //    this.entityInitializer(entity);
                //Entity = entity;
                isEntityNewAndUnmodified = true;
            }
        }

        protected void LoadEntityByKey(string primaryKey)
        {
        }

        private void UpdateTitle()
        {
            if (ViewEntity == null)
            {
                title = null;
            }
            else if (IsNew())
            {
                title = GetTitleForNewEntity();
            }
            else
            {
                title = GetTitle(GetState() == EntityState.Modified);
            }

            this.RaisePropertyChanged(x => x.Title);
        }

        protected virtual void UpdateCommands()
        {
            this.RaiseCanExecuteChanged(x => x.Save());
            this.RaiseCanExecuteChanged(x => x.SaveAndClose());
            this.RaiseCanExecuteChanged(x => x.SaveAndNew());
            this.RaiseCanExecuteChanged(x => x.Delete());
            this.RaiseCanExecuteChanged(x => x.Reset());
        }

        protected IDocumentOwner DocumentOwner { get; private set; }

        protected virtual void OnDestroy()
        {
            Messenger.Default.Unregister(this);
            RefreshLookUpCollections(false);
        }

        protected virtual bool TryClose()
        {
            if (HasValidationErrors())
            {
                MessageResult warningResult = MessageBoxService.ShowMessage(CommonResources.Warning_SomeFieldsContainInvalidData, CommonResources.Warning_Caption, MessageButton.OKCancel);
                return warningResult == MessageResult.OK;
            }
            if (!NeedReset())
            {
                return true;
            }

            MessageResult result = MessageBoxService.ShowMessage(CommonResources.Confirmation_Save, GetConfirmationMessageTitle(), MessageButton.YesNoCancel);

            if (result == MessageResult.No)
                Reload();
            return result != MessageResult.Cancel;
        }

        protected virtual void OnClosing(CloseAllMessage message)
        {
            if (!message.Cancel)
            {
                message.Cancel = !TryClose();
            }
        }

        protected virtual string GetConfirmationMessageTitle()
        {
            return GetTitle();
        }

        public bool IsNew()
        {
            return GetState() == EntityState.Added;
        }

        protected virtual bool NeedSave()
        {
            if (ViewEntity == null)
                return false;
            EntityState state = GetState();
            return state == EntityState.Modified || state == EntityState.Added;
        }

        protected virtual bool NeedReset()
        {
            return NeedSave() && !isEntityNewAndUnmodified;
        }

        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = ViewEntity as IDataErrorInfo;
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }

        private string GetTitle(bool entityModified)
        {
            return GetTitle() + (entityModified ? CommonResources.Entity_Changed : string.Empty);
        }

        protected virtual string GetTitleForNewEntity()
        {
            return typeof(TEntity).Name + CommonResources.Entity_New;
        }

        protected virtual string GetTitle()
        {
            return (typeof(TEntity).Name + " - " + Convert.ToString(getEntityDisplayNameFunc != null ? getEntityDisplayNameFunc(ViewEntity) : PrimaryKey))
            .Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        }

        protected EntityState GetState()
        {
            try
            {
                return EntityState.Unchanged;
            }
            catch (InvalidOperationException)
            {
                return EntityState.Unchanged;
            }
        }

        #region look up and detail view models

        protected virtual void RefreshLookUpCollections(bool raisePropertyChanged)
        {
            var values = lookUpViewModels.ToArray();
            lookUpViewModels.Clear();
            foreach (var item in values)
            {
                item.Value.OnDestroy();
                if (raisePropertyChanged)
                    ((IPOCOViewModel)this).RaisePropertyChanged(item.Key);
            }
        }

        #endregion look up and detail view models

        #region ISupportParameter

        object ISupportParameter.Parameter
        {
            get { return null; }
            set { OnParameterChanged(value); }
        }

        #endregion ISupportParameter

        #region IDocumentContent

        object IDocumentContent.Title { get { return Title; } }

        void IDocumentContent.OnClose(CancelEventArgs e)
        {
            e.Cancel = !TryClose();
            Messenger.Default.Send(new DestroyOrphanedDocumentsMessage());
        }

        void IDocumentContent.OnDestroy()
        {
            OnDestroy();
        }

        IDocumentOwner IDocumentContent.DocumentOwner
        {
            get { return DocumentOwner; }
            set { DocumentOwner = value; }
        }

        #endregion IDocumentContent

        #region ISingleObjectViewModel

        TViewEntity ISingleObjectViewModel<TViewEntity>.ViewEntity => ViewEntity;

        #endregion ISingleObjectViewModel

        #region ISupportLogicalLayout

        bool ISupportLogicalLayout.CanSerialize
        {
            get { return ViewEntity != null && !IsNew(); }
        }

        string ISupportLogicalLayout<string>.SaveState()
        {
            return PrimaryKey;
        }

        void ISupportLogicalLayout<string>.RestoreState(string key)
        {
            LoadEntityByKey(key);
        }

        IDocumentManagerService ISupportLogicalLayout.DocumentManagerService
        {
            get { return this.GetService<IDocumentManagerService>(); }
        }

        IEnumerable<object> ISupportLogicalLayout.LookupViewModels
        {
            get { return lookUpViewModels.Values; }
        }

        private object? _ParentViewModel;

        object? ISupportParentViewModel.ParentViewModel
        {
            get => _ParentViewModel;
            set
            {
                _ParentViewModel = value;
                if (_ParentViewModel is not null)
                {
                    OnParentViewModelChanged(_ParentViewModel);
                }
            }
        }

        /// <summary>
        /// public TViewEntity OldEntity => throw new NotImplementedException();
        /// </summary>
        public virtual TViewEntity OldViewEntity { get; set; }

        protected void OnParentViewModelChanged(object ParentViewModel)
        {
            int a = 2;
        }

        #endregion ISupportLogicalLayout
    }

    public enum SingleModelAction
    {
        New,
        Copy,
        Edit
    }
}