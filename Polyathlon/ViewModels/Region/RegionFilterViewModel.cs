using Polyathlon.DataModel.Entities;

namespace Polyathlon.ViewModels;

public class RegionFilterViewModel : FilterViewModel<DataModel.Entities.Region, RegionInfoWithSales> {
    public RegionFilterViewModel()
        : base(new FilterModelPageSpecificSettings<Properties.Settings>(Properties.Settings.Default, null, x => x.RegionCustomFilters), 
        new Action<object, Action>(FiltersSettings.RegisterEntityChangedMessageHandler<DataModel.Entities.Region, long>)) {
    }
}