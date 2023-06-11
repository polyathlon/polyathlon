using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Referee = Polyathlon.Models.Entities.Referee;

namespace Polyathlon.ViewModels
{
    public partial class RefereeViewModel : SingleObjectViewModel<Referee, RefereeViewEntity, long>
    {
        public static RefereeViewModel Create()
        {
            return ViewModelSource.Create(() => new RefereeViewModel());
        }

        protected static RefereeViewEntity CreateNewViewEntity(Referee region, Flurl.Url request)
        {
            Referee entity = region with { };
            RefereeViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected RefereeViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}