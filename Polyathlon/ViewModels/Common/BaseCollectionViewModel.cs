using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using Polyathlon.DataModel;
using Polyathlon.DataModel.Common;
using Polyathlon.DataModel.Entities;

namespace Polyathlon.ViewModels.Common;

[POCOViewModel]
public partial class BaseCollectionViewModel<TEntity, TViewEntity> : ISupportParameter//, ISupportParentViewModel
   where TEntity : EntityBase
   where TViewEntity : ViewEntityBase<TEntity> //, ISupportParentViewModel //: CollectionViewModel<Entities.Region, RegionInfoWithSales, long, IDbUnitOfWork>    
{
    private ModuleDatabase moduleDb;

    public ModuleViewEntity ModuleDescription { get; private set; }

    public ObservableCollection<TViewEntity> Entities { get; set; }

    protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }

    CancellationTokenSource loadCancellationTokenSource;

    public virtual void Delete(TViewEntity ViewEntity) {        
        if (MessageBoxService.ShowMessage(string.Format(CommonResources.Confirmation_Delete, typeof(TEntity).Name), CommonResources.Confirmation_Caption, MessageButton.YesNo) != MessageResult.Yes)
            return;
        try {
            Entities.Remove(ViewEntity);
            this.RaisePropertyChanged(y => y.Entities);
            //Entities.Remove(ViewEntity);
            //TPrimaryKey primaryKey = Repository.GetProjectionPrimaryKey(projectionEntity);
            //TEntity entity = Repository.Find(primaryKey);
            //if (entity != null) {
            //    OnBeforeEntityDeleted(primaryKey, entity);
            //    Repository.Remove(entity);
            //    Repository.UnitOfWork.SaveChanges();
            //    OnEntityDeleted(primaryKey, entity);
            //}
        }
        catch (DbException e) {
            //Refresh();
            MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.Error);
        }
    }
    //public static BaseCollectionViewModel Create(object a)
    //{
    //    //Debug.WriteLine("111");
    //    return ViewModelSource.Create(() => new RegionCollectionViewModel(LocalViewDbBase.LocalViewDb));
    //}



    public virtual bool IsLoading { get; protected set; } = false;
    
    public virtual object Parameter { get; set; }

   // public object ParentViewModel { get => null; set => OnParentViewModelChanged(value); }
    //public object ParentViewModel { get; set; }


    /// <summary>
    /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
    /// </summary>
    /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
    //public static RegionCollectionViewModel Create(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
    //{
    //    return ViewModelSource.Create(() => new RegionCollectionViewModel(unitOfWorkFactory));
    //}

    /// <summary>
    /// Initializes a new instance of the CustomerCollectionViewModel class.
    /// This constructor is declared protected to avoid undesired instantiation of the CustomerCollectionViewModel type without the POCO proxy factory.
    /// </summary>
    /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
    //protected RegionCollectionViewModel(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
    //    //: base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Customers, query => DevExpress.DevAV.QueriesHelper.GetCustomerInfoWithSales(query))
    //    : base(unitOfWorkFactory, x => null, null)
    //{
    //}

    protected BaseCollectionViewModel(Func<TEntity, Flurl.Url, TViewEntity> createViewEntity)
    {
        moduleDb = ModuleDatabase.ModuleDb;
        this.createViewEntity = createViewEntity;
    }

    TViewEntity _selectedEntity;
    public virtual TViewEntity SelectedEntity {
        get {
            return _selectedEntity; 
        }
        set {
            _selectedEntity = value;
        }
    }

    public Func<TEntity, Flurl.Url, TViewEntity> createViewEntity;

    protected void OnParameterChanged()
    {
        ModuleDescription = (ModuleViewEntity)Parameter;
        LoadEntities();
        //LoadEntities();
        //Entities = new(moduleDb.GetModuleViewCollection<TEntity, TViewEntity>(ModuleDescription, createViewEntity).Values);
        //IsLoading = false;
    }

    //protected void OnParentViewModelChanged(object parentViewModel)
    //{
    //    //ModuleDescription = (PolyathlonModuleDescription)Parameter;
    //    ////LoadCore();
    //    //Entities = localViewDb.GetLocalViewCollection<TEntity, TViewEntity>(ModuleDescription, createViewEntity);
    //    //IsLoading = false;
    //}
    protected IDocumentManagerService DocumentManagerService { get { return this.GetService<IDocumentManagerService>(); } }

    //public object ParentViewModel { get; set; }

    readonly Action<DataModel.Entities.Region> newEntityInitializer;

    public void New()
    {
        DocumentManagerService.MyShowNewEntityDocument<TEntity>(SingleModelAction.New, this);
    }

    public void Edit(TViewEntity viewEntity)
    {
        DocumentManagerService.ShowMyExistingEntityDocument<TEntity, TViewEntity>((viewEntity, SingleModelAction.Edit), this);
    }

    public void Copy(TViewEntity viewEntity) {
        DocumentManagerService.ShowMyExistingEntityDocument<TEntity, TViewEntity>((viewEntity, SingleModelAction.Copy), this);
    }

    protected void LoadEntities(bool forceLoad = false) {
        if (forceLoad) {
            if (loadCancellationTokenSource != null)
                loadCancellationTokenSource.Cancel();
        } else if (IsLoading) {
            return;
        }
        loadCancellationTokenSource = LoadEntitiesTask();
    }

    CancellationTokenSource LoadEntitiesTask() {
        IsLoading = true;
        var cancellationTokenSource = new CancellationTokenSource();
        System.Threading.Tasks.Task.Factory.StartNew(() => {
            var entities = new ObservableCollection<TViewEntity>(moduleDb.GetModuleViewCollection<TEntity, TViewEntity>(ModuleDescription, createViewEntity).Values);
            //var entities = localViewDb.GetLocalViewCollection<RegionViewEntity, DataModel.Entities.Region>(ModuleDescription, createViewEntity);
            return entities;
        }).ContinueWith(x => {
            Entities = x.Result;
            this.RaisePropertyChanged(m => m.Entities);
            IsLoading = false;
        }, cancellationTokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        return cancellationTokenSource;
    }

    //protected RegionCollectionViewModel(object a)    
    //{

    //}

    //protected BaseCollectionViewModel(object a)
    //{
    //    this.localViewDb = LocalViewDbBase.LocalViewDb;
    //}
    protected BaseCollectionViewModel()
    {
        moduleDb = ModuleDatabase.ModuleDb;
    }
}
