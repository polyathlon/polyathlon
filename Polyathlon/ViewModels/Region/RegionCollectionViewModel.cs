using DevExpress.Mvvm.POCO;
using Polyathlon.DataModel;
using System.Collections.ObjectModel;


namespace Polyathlon.ViewModels
{
    /// <summary>
    /// Represents the Region collection view model.
    /// </summary>
    public partial class RegionCollectionViewModel //: CollectionViewModel<Entities.Region, RegionInfoWithSales, long, IDbUnitOfWork>
    {
        /// <summary>
        /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>

        private LocalViewDbBase localViewDb;
        public ObservableCollection<DataModel.Entities.Region> Entities;
        public static RegionCollectionViewModel Create()
        {
            return ViewModelSource.Create(() => new RegionCollectionViewModel(LocalViewDbBase.LocalViewDb));
        }

        public bool IsLoading { get; set; } = false;


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
            Entities = LocalViewDbBase.GetLocalViewTable<DataModel.Entities.Region, DataModel.Entities.Region>("11", createViewEntity);
        }

        protected DataModel.Entities.Region createViewEntity(DataModel.Entities.Region Entity)
        {
            DataModel.Entities.Region ViewEntity = new(Entity);
            return ViewEntity;
        }

        protected RegionCollectionViewModel()    
        {
            this.localViewDb = LocalViewDbBase.LocalViewDb;
            //LocalViewDbBase.GetLocalViewTable<DataModel.Entities.Region, DataModel.Entities.Region>('11');
            //Entities = (ObservableCollection<DataModel.Entities.Region>)LocalViewDbBase.GetLocalViewTable<DataModel.Entities.Region, DataModel.Entities.Region>("11");
            Entities = LocalViewDbBase.GetLocalViewTable<DataModel.Entities.Region, DataModel.Entities.Region>("11", createViewEntity);
            IsLoading = true;
        }
    }
}
