using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using RefereeBoard = Polyathlon.Models.Entities.RefereeBoard;

namespace Polyathlon.ViewModels
{
    public partial class RefereeBoardViewModel : SingleObjectViewModel<RefereeBoard, RefereeBoardViewEntity, long>
    {
        public static RefereeBoardViewModel Create()
        {
            return ViewModelSource.Create(() => new RefereeBoardViewModel());
        }

        protected static RefereeBoardViewEntity CreateNewViewEntity(RefereeBoard region, Flurl.Url request)
        {
            RefereeBoard entity = region with { };
            RefereeBoardViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected RefereeBoardViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}