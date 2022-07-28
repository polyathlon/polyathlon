using DevExpress.Mvvm.POCO;
using Polyathlon.DataModel;
using System.Collections.ObjectModel;
using Polyathlon.DataModel.Entities;
using System.Diagnostics;
using DevExpress.Mvvm;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.ViewModels
{
    /// <summary>
    /// Represents the Region collection view model.
    /// </summary>
    public partial class RegionCollectionViewModel : ISupportParameter, ISupportParentViewModel //: CollectionViewModel<Entities.Region, RegionInfoWithSales, long, IDbUnitOfWork> 
    {
        /// <summary>
        /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>

        private LocalViewDbBase localViewDb;
        
        private PolyathlonModuleDescription ModuleDescription;
        public ObservableCollection<RegionViewEntity> Entities;
        public static RegionCollectionViewModel Create(object a)
        {
            //Debug.WriteLine("111");
            return ViewModelSource.Create(() => new RegionCollectionViewModel(LocalViewDbBase.LocalViewDb));
        }

        public bool IsLoading { get; set; } = true;
        public virtual object Parameter { get; set; }
        public object ParentViewModel { get; set; }


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

        protected RegionCollectionViewModel(LocalViewDbBase localViewDbBase)
        {
            this.localViewDb = localViewDbBase;
            
            //Entities = LocalViewDbBase.GetLocalViewTable<DataModel.Entities.Region, DataModel.Entities.Region>("11", createViewEntity);
        }

        protected RegionViewEntity createViewEntity(DataModel.Entities.Region Entity)
        {
            RegionViewEntity ViewEntity = new(Entity);
            return ViewEntity;
        }
        

        protected void OnParameterChanged()
        {

            ModuleDescription = (PolyathlonModuleDescription)Parameter;
            //Debug.WriteLine(this.ParentViewModel);
            //Debug.WriteLine(Parameter.ToString());
            //this.localViewDb = LocalViewDbBase.LocalViewDb;
            //LocalViewDbBase.GetLocalViewTable<DataModel.Entities.Region, DataModel.Entities.Region>('11');
            //Entities = (ObservableCollection<DataModel.Entities.Region>)LocalViewDbBase.GetLocalViewTable<DataModel.Entities.Region, DataModel.Entities.Region>("11");
            //Entities = localViewDb.GetLocalViewCollection<RegionViewEntity, DataModel.Entities.Region>(ModuleDescription, createViewEntity);
            // Entities = new ObservableCollection<Account>();
            //Entities.Add(new Account());
            //Entities.Add(new Account());
            //LoadCore();
            Entities = localViewDb.GetLocalViewCollection<RegionViewEntity, DataModel.Entities.Region>(ModuleDescription, createViewEntity);
            IsLoading = false;
        }

        CancellationTokenSource LoadCore()
        {
            IsLoading = true;
            var cancellationTokenSource = new CancellationTokenSource();            
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {                
                var entities = localViewDb.GetLocalViewCollection<RegionViewEntity, DataModel.Entities.Region>(ModuleDescription, createViewEntity);
                return entities;
            }).ContinueWith(x =>
            {                   
                 Entities = x.Result;                
                 IsLoading = false;
            }, cancellationTokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            return cancellationTokenSource;
        }

        //protected RegionCollectionViewModel(object a)    
        //{

        //}

        protected RegionCollectionViewModel(object a)
        {
            this.localViewDb = LocalViewDbBase.LocalViewDb;
        }
        protected RegionCollectionViewModel()
        {
            this.localViewDb = LocalViewDbBase.LocalViewDb;
        }
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
