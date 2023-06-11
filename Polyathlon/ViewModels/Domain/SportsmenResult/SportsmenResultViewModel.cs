using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using SportsmenResult = Polyathlon.Models.Entities.SportsmenResult;

namespace Polyathlon.ViewModels
{
    public partial class SportsmenResultViewModel : SingleObjectViewModel<SportsmenResult, SportsmenResultViewEntity, long>
    {
        public static SportsmenResultViewModel Create()
        {
            return ViewModelSource.Create(() => new SportsmenResultViewModel());
        }

        protected static SportsmenResultViewEntity CreateNewViewEntity(SportsmenResult region, Flurl.Url request)
        {
            SportsmenResult entity = region with { };
            SportsmenResultViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected SportsmenResultViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}