using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Sportsmen = Polyathlon.Models.Entities.Sportsmen;

namespace Polyathlon.ViewModels
{
    public partial class SportsmenViewModel : SingleObjectViewModel<Sportsmen, SportsmenViewEntity, long>
    {
        public static SportsmenViewModel Create()
        {
            return ViewModelSource.Create(() => new SportsmenViewModel());
        }

        protected static SportsmenViewEntity CreateNewViewEntity(Sportsmen region, Flurl.Url request)
        {
            Sportsmen entity = region with { };
            SportsmenViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected SportsmenViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}