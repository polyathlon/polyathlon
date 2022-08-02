
using DevExpress.Mvvm.POCO;
using System.Drawing;
using DevExpress.XtraMap;
using Polyathlon.DbDataModel;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.ViewModels {
    public partial class RegionViewModel : SingleObjectViewModel<DataModel.Entities.Region, DataModel.Entities.RegionViewEntity, long>
    
    {
        protected override void OnInitializeInRuntime() {
            base.OnInitializeInRuntime();
           // MapViewModel = MapViewModel.Create().SetParentViewModel(this);
            //DetailKind = DetailKind.Stores;
        }
        public MapViewModel MapViewModel { get; private set; }
        public virtual DetailKind DetailKind { get; set; }
        protected void OnDetailKindChanged() {
            //this.RaiseCanExecuteChanged(x => x.ShowOrders());
            //this.RaiseCanExecuteChanged(x => x.ShowStores());
        }
        public void ShowOrders() {
            DetailKind = DetailKind.Orders;
        }
        public bool CanShowOrders() {
            return DetailKind != DetailKind.Orders;
        }
        public void ShowStores() {
            DetailKind = DetailKind.Stores;
        }
        public bool CanShowStores() {
            return DetailKind != DetailKind.Stores;
        }
        public virtual DateRange DateRange { get; set; }
        protected void OnDateRangeChanged() {
            MapViewModel.Update(GetMapItems());
        }
        public List<MapItemModel> GetMapItems() {
            
            //if(Entity != null) {
            //    var customerStores = Entity.CustomerStores.GroupBy(s => s.City).Select(s => s.First());
            //    return customerStores.Select(s => new MapItemModel() {
            //        City = s.Address.City,
            //        Longitude = s.Address.Longitude,
            //        Latitude = s.Address.Latitude,
            //        TotalSales = s.Customer.Orders.Where(o => o.StoreId == s.Id && o.OrderDate >= DateRange.Minimum && o.OrderDate <= DateRange.Maximum).Sum(o => o.TotalAmount),
            //        TotalQuotes = GetQuotesTotal(s, DateRange.Minimum, DateRange.Maximum)
            //    }).Where(s => s.TotalSales != 0M).ToList();
            //}
            return null;
        }
        //public decimal GetQuotesTotal(CustomerStore store, DateTime begin, DateTime end) {
        //    return QueriesHelper.GetQuotesTotal(UnitOfWork.Quotes, store, DateRange.Minimum, DateRange.Maximum);
        //}
    }
    public enum DetailKind {
        Orders,
        Stores
    }
    
    public class MapItemModel {
        public string City { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalQuotes { get; set; }
    }
}
