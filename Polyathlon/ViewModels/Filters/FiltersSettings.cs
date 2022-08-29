using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.ViewModels {
    public static class FiltersSettings {
        //public static EmployeeTaskFilterViewModel GetTaskFilter(object parentViewModel) {
        //    return ViewModelSource.Create<EmployeeTaskFilterViewModel>().SetParentViewModel(parentViewModel);
        //}

        //public static EmployeesFilterViewModel GetEmployeeFilter(object parentViewModel) {
        //    return ViewModelSource.Create<EmployeesFilterViewModel>().SetParentViewModel(parentViewModel);
        //}

        //public static ProductFilterViewModel GetProductFilter(object parentViewModel) {
        //    return ViewModelSource.Create<ProductFilterViewModel>().SetParentViewModel(parentViewModel);
        //}

        //public static RegionFilterViewModel GetCustomerFilter(object parentViewModel)
        //{
        //    return ViewModelSource.Create<RegionFilterViewModel>().SetParentViewModel(parentViewModel);
        //}

        public static void RegisterEntityChangedMessageHandler<TEntity, TPrimaryKey>(object recipient, Action handler)
        {
            Messenger.Default.Register<EntityMessage<TEntity, TPrimaryKey>>(recipient, message => handler());
        }
    }
}
