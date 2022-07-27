using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;
using Polyathlon.DataModel.Entities;


namespace Polyathlon.ViewModels {
    public partial class RegionCollectionViewModel : IFilterTreeViewModelContainer<DataModel.Entities.Region, RegionInfoWithSales> {
        public FilterViewModel<DataModel.Entities.Region, RegionInfoWithSales> FilterViewModel { get; set; }
        public ICollection<double> GetMonthlySalesByCustomer(DataModel.Entities.Region customer)
        {
            //if (customer == null || customer.Orders == null)
                return new double[0];
            //return null;// customer.Orders.GroupBy(o => o.OrderDate.Month).Select(g => (double)g.CustomSum(i => i.TotalAmount)).ToList();
        }
        //protected override void OnEntitiesLoaded(DbDataModel.IDbUnitOfWork unitOfWork, IEnumerable<RegionInfoWithSales> entities) {
        //    base.OnEntitiesLoaded(unitOfWork, entities);
        //   // DevExpress.DevAV.QueriesHelper.UpdateCustomerInfoWithSales(entities, unitOfWork.CustomerStores, unitOfWork.CustomerEmployees, unitOfWork.Orders.ActualOrders());
        //}
        public void CustomFilter() {
            Messenger.Default.Send(new CreateCustomFilterMessage<DataModel.Entities.Region>());
        }
    }

    public enum CollectionDetailKind {
        Contacts,
        Stores
    }
}
