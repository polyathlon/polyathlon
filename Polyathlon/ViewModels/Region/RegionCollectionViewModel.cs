using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

using Polyathlon.DataModel;
using Polyathlon.DataModel.Entities;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.ViewModels;

/// <summary>
/// Represents the Region collection view model.
/// </summary>
public partial class RegionCollectionViewModel : BaseCollectionViewModel<DataModel.Entities.Region, RegionViewEntity>, ISupportParameter//, ISupportParentViewModel //: CollectionViewModel<Entities.Region, RegionInfoWithSales, long, IDbUnitOfWork> 
{
    /// <summary>
    /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
    /// </summary>
    /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>

    //private LocalViewDbBase localViewDb;
    
    //public PolyathlonModuleDescription ModuleDescription { get; private set; }

    //public ObservableCollection<RegionViewEntity> Entities { get; private set; }

    public static RegionCollectionViewModel Create()
    {            
        return ViewModelSource.Create(() => new RegionCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;
    //public virtual object Parameter { get; set; }
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

    //protected RegionCollectionViewModel(LocalViewDbBase localViewDbBase)
    //{
    //    this.localViewDb = localViewDbBase;
    //}

    //public override void Delete(RegionViewEntity ViewEntity) {
    //    //IsLoading = true;
    //   // ModuleDescription.Tile.Title = "11";
    //}

    protected static RegionViewEntity CreateViewEntity(DataModel.Entities.Region entity, Flurl.Url origin)
    {
        RegionViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    //public virtual RegionViewEntity SelectedEntity { get; set; }

    //protected void OnParameterChanged()
    //{

    //    ModuleDescription = (PolyathlonModuleDescription)Parameter;
    //    //LoadCore();
    //    Entities = localViewDb.GetLocalViewCollection<RegionViewEntity, DataModel.Entities.Region>(ModuleDescription, createViewEntity);
    //    IsLoading = false;
    //}
    //protected IDocumentManagerService DocumentManagerService { get { return this.GetService<IDocumentManagerService>(); } }

    //readonly Action<DataModel.Entities.Region> newEntityInitializer;

    //public void New()
    //{
    //    DocumentManagerService.ShowNewEntityDocument(this, newEntityInitializer);
    //}

    //public void Edit(RegionViewEntity viewEntity)
    //{
    //    DocumentManagerService.ShowNewEntityDocument(this, newEntityInitializer);
    //}
    //CancellationTokenSource LoadCore()
    //{
    //    IsLoading = true;
    //    var cancellationTokenSource = new CancellationTokenSource();            
    //    System.Threading.Tasks.Task.Factory.StartNew(() =>
    //    {                
    //        var entities = localViewDb.GetLocalViewCollection<RegionViewEntity, DataModel.Entities.Region>(ModuleDescription, createViewEntity);
    //        return entities;
    //    }).ContinueWith(x =>
    //    {                   
    //         Entities = x.Result;                
    //         IsLoading = false;
    //    }, cancellationTokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    //    return cancellationTokenSource;
    //}

    //protected RegionCollectionViewModel(object a)    
    //{

    //}

    //protected RegionCollectionViewModel(LocalViewDbBase localViewDb) :
    //    base(localViewDb)
    //{
    //    createViewEntity = CreateViewEntity;
    //}
    protected RegionCollectionViewModel() : base (CreateViewEntity)
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
