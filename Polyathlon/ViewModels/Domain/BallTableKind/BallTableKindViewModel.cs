using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using BallTableKind = Polyathlon.Models.Entities.BallTableKind;

namespace Polyathlon.ViewModels
{
    public partial class BallTableKindViewModel : SingleObjectViewModel<BallTableKind, BallTableKindViewEntity, long>
    {
        public static BallTableKindViewModel Create()
        {
            return ViewModelSource.Create(() => new BallTableKindViewModel());
        }

        protected static BallTableKindViewEntity CreateNewViewEntity(BallTableKind region, Flurl.Url request)
        {
            BallTableKind entity = region with { };
            BallTableKindViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected BallTableKindViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}