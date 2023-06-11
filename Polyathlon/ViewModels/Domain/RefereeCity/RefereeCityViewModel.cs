using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using RefereeCity = Polyathlon.Models.Entities.RefereeCity;

namespace Polyathlon.ViewModels
{
    public partial class RefereeCityViewModel : SingleObjectViewModel<RefereeCity, RefereeCityViewEntity, long>
    {
        public static RefereeCityViewModel Create()
        {
            return ViewModelSource.Create(() => new RefereeCityViewModel());
        }

        protected static RefereeCityViewEntity CreateNewViewEntity(RefereeCity region, Flurl.Url request)
        {
            RefereeCity entity = region with { };
            RefereeCityViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected RefereeCityViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}