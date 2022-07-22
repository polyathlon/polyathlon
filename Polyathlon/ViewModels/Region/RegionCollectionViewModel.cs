using System;
using System.Linq;
using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.DataModel.Entities;
using Polyathlon.DbDataModel;
using Polyathlon.DataModel;

namespace Polyathlon.ViewModels
{
    /// <summary>
    /// Represents the Region collection view model.
    /// </summary>
    public partial class RegionCollectionViewModel : CollectionViewModel<Entities.Region, RegionInfoWithSales, long, IDbUnitOfWork>
    {

        /// <summary>
        /// Creates a new instance of CustomerCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static RegionCollectionViewModel Create(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new RegionCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the CustomerCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CustomerCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected RegionCollectionViewModel(IUnitOfWorkFactory<IDbUnitOfWork> unitOfWorkFactory = null)
            //: base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Customers, query => DevExpress.DevAV.QueriesHelper.GetCustomerInfoWithSales(query))
            : base(unitOfWorkFactory, x => null, null)
        {
        }
    }
}
