using DevExpress.DevAV.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.DevAV.ViewModels {
    public class CustomerFilterViewModel : FilterViewModel<Customer, CustomerInfoWithSales> {
        public CustomerFilterViewModel()
            : base(new FilterModelPageSpecificSettings<Settings>(Settings.Default, null, x => x.CustomerCustomFilters), 
            new Action<object, Action>(FiltersSettings.RegisterEntityChangedMessageHandler<Customer, long>)) {
        }
    }
}
