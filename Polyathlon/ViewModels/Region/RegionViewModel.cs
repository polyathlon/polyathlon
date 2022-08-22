using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
//using DevExpress.DevAV.Common.Utils;
//using DevExpress.DevAV.DevAVDbDataModel1;
//using DevExpress.DevAV.Common.DataModel;
//using DevExpress.DevAV;
//using DevExpress.DevAV.Common.ViewModel;
using Polyathlon.ViewModels.Common;
using Polyathlon.DbDataModel;
using Polyathlon.DataModel;
using Polyathlon.DataModel.Entities;

using Region = Polyathlon.DataModel.Entities.Region;


namespace Polyathlon.ViewModels
{
    /// <summary>
    /// Represents the single Customer object view model.
    /// </summary>
    public partial class RegionViewModel : SingleObjectViewModel<Region, RegionViewEntity, long>
    {

        /// <summary>
        /// Creates a new instance of CustomerViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static RegionViewModel Create(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new RegionViewModel(unitOfWorkFactory));
        }

        protected static RegionViewEntity createNewViewEntity(Region region) {
            Region entity = region with { };
            RegionViewEntity regionViewEntity = new(entity, "111");
            return regionViewEntity;
        }

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CustomerViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected RegionViewModel(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
            : base(createNewViewEntity)
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
        //    get { return GetDetailsCollectionViewModel((RegionViewModel x) => x.RegionStoresDetails, x => x.CustomerStores, x => x.CustomerId, (x, key) => x.CustomerId = key); }
        //}
    }
}
