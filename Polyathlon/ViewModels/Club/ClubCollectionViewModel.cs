using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.ViewModels;

/// <summary>
/// Represents the Club collection view model.
/// </summary>
public partial class ClubCollectionViewModel : CollectionViewModel<ClubViewEntity, Club>, ISupportParameter//, ISupportParentViewModel //: CollectionViewModel<Entities.Club, ClubInfoWithSales, long, IDbUnitOfWork> 
{
    /// <summary>
    /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
    /// </summary>    

    //private LocalViewDbBase localViewDb;
    
    //public PolyathlonModuleDescription ModuleDescription { get; private set; }

    //public ObservableCollection<ClubViewEntity> Entities { get; private set; }

    public static ClubCollectionViewModel Create()
    {            
        return ViewModelSource.Create(() => new ClubCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;
    //public virtual object Parameter { get; set; }
    //public object ParentViewModel { get; set; }


    /// <summary>
    /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
    /// </summary>
    /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
    //public static ClubCollectionViewModel Create(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
    //{
    //    return ViewModelSource.Create(() => new ClubCollectionViewModel(unitOfWorkFactory));
    //}

    /// <summary>
    /// Initializes a new instance of the CustomerCollectionViewModel class.
    /// This constructor is declared protected to avoid undesired instantiation of the CustomerCollectionViewModel type without the POCO proxy factory.
    /// </summary>
    /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
    //protected ClubCollectionViewModel(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
    //    //: base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Customers, query => DevExpress.DevAV.QueriesHelper.GetCustomerInfoWithSales(query))
    //    : base(unitOfWorkFactory, x => null, null)
    //{
    //}

    //protected ClubCollectionViewModel(LocalViewDbBase localViewDbBase)
    //{
    //    this.localViewDb = localViewDbBase;
    //}

    //public override void Delete(ClubViewEntity ViewEntity) {
    //    //IsLoading = true;
    //   // ModuleDescription.Tile.Title = "11";
    //}

    protected static ClubViewEntity CreateViewEntity(Club entity, Flurl.Url origin)
    {
        ClubViewEntity viewEntity = new(entity, origin);
        return viewEntity;
    }

    //public virtual ClubViewEntity SelectedEntity { get; set; }

    //protected void OnParameterChanged()
    //{

    //    ModuleDescription = (PolyathlonModuleDescription)Parameter;
    //    //LoadCore();
    //    Entities = localViewDb.GetLocalViewCollection<ClubViewEntity, DataModel.Entities.Club>(ModuleDescription, createViewEntity);
    //    IsLoading = false;
    //}
    //protected IDocumentManagerService DocumentManagerService { get { return this.GetService<IDocumentManagerService>(); } }

    //readonly Action<DataModel.Entities.Club> newEntityInitializer;

    //public void New()
    //{
    //    DocumentManagerService.ShowNewEntityDocument(this, newEntityInitializer);
    //}

    //public void Edit(ClubViewEntity viewEntity)
    //{
    //    DocumentManagerService.ShowNewEntityDocument(this, newEntityInitializer);
    //}
    //CancellationTokenSource LoadCore()
    //{
    //    IsLoading = true;
    //    var cancellationTokenSource = new CancellationTokenSource();            
    //    System.Threading.Tasks.Task.Factory.StartNew(() =>
    //    {                
    //        var entities = localViewDb.GetLocalViewCollection<ClubViewEntity, DataModel.Entities.Club>(ModuleDescription, createViewEntity);
    //        return entities;
    //    }).ContinueWith(x =>
    //    {                   
    //         Entities = x.Result;                
    //         IsLoading = false;
    //    }, cancellationTokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    //    return cancellationTokenSource;
    //}

    //protected ClubCollectionViewModel(object a)    
    //{

    //}

    //protected ClubCollectionViewModel(LocalViewDbBase localViewDb) :
    //    base(localViewDb)
    //{
    //    createViewEntity = CreateViewEntity;
    //}
    protected ClubCollectionViewModel() : base (CreateViewEntity)
    {
        //this.localViewDb = LocalViewDbBase.LocalViewDb;
        //createViewEntity1 = CreateViewEntity;
    }
}



//public class Account
//{
//    [Key, Display(AutoGenerateField = false)]
//    public long ID { get; set; }
//    [Required, StringLength(30, MinimumLength = 4)]
//    [Display(Name = "ACCOUNT")]
//    public string Name { get; set; } = "12";
//    [DataType(DataType.Currency)]
//    [Display(Name = "AMOUNT")]
//    public decimal Amount { get; set; } = 1;
//    public override string ToString()
//    {
//        return Name + " (" + Amount.ToString("C") + ")";
//    }    
//}
