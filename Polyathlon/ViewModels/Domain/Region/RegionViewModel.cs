using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Region = Polyathlon.Models.Entities.Region;

namespace Polyathlon.ViewModels
{
    public partial class RegionViewModel : SingleObjectViewModel<Region, RegionViewEntity, long>
    {
        public static RegionViewModel Create()
        {
            return ViewModelSource.Create(() => new RegionViewModel());
        }

        protected static RegionViewEntity CreateNewViewEntity(Region region, Flurl.Url request)
        {
            Region entity = region with { };
            RegionViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected RegionViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}