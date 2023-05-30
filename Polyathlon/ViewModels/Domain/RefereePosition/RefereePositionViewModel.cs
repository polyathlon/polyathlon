using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using RefereePosition = Polyathlon.Models.Entities.RefereePosition;

namespace Polyathlon.ViewModels
{
    public partial class RefereePositionViewModel : SingleObjectViewModel<RefereePosition, RefereePositionViewEntity, long>
    {
        public static RefereePositionViewModel Create()
        {
            return ViewModelSource.Create(() => new RefereePositionViewModel());
        }

        protected static RefereePositionViewEntity CreateNewViewEntity(RefereePosition region, Flurl.Url request)
        {
            RefereePosition entity = region with { };
            RefereePositionViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected RefereePositionViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}