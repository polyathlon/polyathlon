using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace DevExpress.DevAV.ViewModels {
    public partial class CustomerCollectionViewModel : IFilterTreeViewModelContainer<Customer, CustomerInfoWithSales> {
        public FilterViewModel<Customer, CustomerInfoWithSales> FilterViewModel { get; set; }
        public ICollection<double> GetMonthlySalesByCustomer(Customer customer) {
            if(customer == null || customer.Orders == null) 
                return new double[0];
            return customer.Orders.GroupBy(o => o.OrderDate.Month).Select(g => (double)g.CustomSum(i => i.TotalAmount)).ToList();
        }
        protected override void OnEntitiesLoaded(DevAVDbDataModel1.IDevAVDbUnitOfWork unitOfWork, IEnumerable<CustomerInfoWithSales> entities) {
            base.OnEntitiesLoaded(unitOfWork, entities);
            DevExpress.DevAV.QueriesHelper.UpdateCustomerInfoWithSales(entities, unitOfWork.CustomerStores, unitOfWork.CustomerEmployees, unitOfWork.Orders.ActualOrders());
        }
        public void CustomFilter() {
            Messenger.Default.Send(new CreateCustomFilterMessage<Customer>());
        }
    }

    public enum CollectionDetailKind {
        Contacts,
        Stores
    }
}
