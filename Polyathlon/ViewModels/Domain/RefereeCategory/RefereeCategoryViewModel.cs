using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using RefereeCategory = Polyathlon.Models.Entities.RefereeCategory;

namespace Polyathlon.ViewModels
{
    public partial class RefereeCategoryViewModel : SingleObjectViewModel<RefereeCategory, RefereeCategoryViewEntity, long>
    {
        public static RefereeCategoryViewModel Create()
        {
            return ViewModelSource.Create(() => new RefereeCategoryViewModel());
        }

        protected static RefereeCategoryViewEntity CreateNewViewEntity(RefereeCategory region, Flurl.Url request)
        {
            RefereeCategory entity = region with { };
            RefereeCategoryViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected RefereeCategoryViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}