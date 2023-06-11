using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using BallTable = Polyathlon.Models.Entities.BallTable;

namespace Polyathlon.ViewModels
{
    public partial class BallTableViewModel : SingleObjectViewModel<BallTable, BallTableViewEntity, long>
    {
        public static BallTableViewModel Create()
        {
            return ViewModelSource.Create(() => new BallTableViewModel());
        }

        protected static BallTableViewEntity CreateNewViewEntity(BallTable region, Flurl.Url request)
        {
            BallTable entity = region with { };
            BallTableViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected BallTableViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}