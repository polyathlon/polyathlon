using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using ThrowResult = Polyathlon.Models.Entities.ThrowResult;

namespace Polyathlon.ViewModels
{
    public partial class ThrowResultViewModel : SingleObjectViewModel<ThrowResult, ThrowResultViewEntity, long>
    {
        public static ThrowResultViewModel Create()
        {
            return ViewModelSource.Create(() => new ThrowResultViewModel());
        }

        protected static ThrowResultViewEntity CreateNewViewEntity(ThrowResult region, Flurl.Url request)
        {
            ThrowResult entity = region with { };
            ThrowResultViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected ThrowResultViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}