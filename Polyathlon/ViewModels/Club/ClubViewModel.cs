
using DevExpress.Mvvm.POCO;
using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;



namespace Polyathlon.ViewModels
{
    /// <summary>
    /// Represents the single Customer object view model.
    /// </summary>
    public partial class ClubViewModel : SingleObjectViewModel<Club, ClubViewEntity, long>
    {

        /// <summary>
        /// Creates a new instance of CustomerViewModel as a POCO view model.
        /// </summary>        
        public static ClubViewModel Create()
        {
            return ViewModelSource.Create(() => new ClubViewModel());
        }

        protected static ClubViewEntity CreateNewViewEntity(Club club, Flurl.Url request) {
            Club entity = club with { };
            ClubViewEntity viewEntity = new(entity, request);
            return viewEntity;
        }

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CustomerViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ClubViewModel() : base(CreateNewViewEntity)
        {
        }

        /// <summary>
        /// The view model for the CustomerEmployees detail collection.
        /// </summary>
        //public CollectionViewModel<CustomerEmployee, long, IDbUnitOfWork> CustomerEmployeesDetails
        //{
        //    get { return GetDetailsCollectionViewModel((CustomerViewModel x) => x.CustomerEmployeesDetails, x => x.CustomerEmployees, x => x.CustomerId, (x, key) => x.CustomerId = key); }
        //}

        /// <summary>
        /// The view model for the CustomerOrders detail collection.
        /// </summary>
        //public CollectionViewModel<Order, long, IDevAVDbUnitOfWork> CustomerOrdersDetails
        //{
        //    get { return GetDetailsCollectionViewModel((CustomerViewModel x) => x.CustomerOrdersDetails, x => x.Orders, x => x.CustomerId, (x, key) => x.CustomerId = key); }
        //}

        /// <summary>
        /// The view model for the CustomerQuotes detail collection.
        /// </summary>
        //public CollectionViewModel<Quote, long, IDbUnitOfWork> CustomerQuotesDetails
        //{
        //    get { return GetDetailsCollectionViewModel((CustomerViewModel x) => x.CustomerQuotesDetails, x => x.Quotes, x => x.CustomerId, (x, key) => x.CustomerId = key); }
        //}

        /// <summary>
        /// The view model for the CustomerCustomerStores detail collection.
        /// </summary>
        //public CollectionViewModel<CustomerStore, long, IDbUnitOfWork> CustomerCustomerStoresDetails
        //{
        //    get { return GetDetailsCollectionViewModel((ClubViewModel x) => x.ClubStoresDetails, x => x.CustomerStores, x => x.CustomerId, (x, key) => x.CustomerId = key); }
        //}
    }
}
