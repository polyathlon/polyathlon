using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using ExerciseKind = Polyathlon.Models.Entities.ExerciseKind;

namespace Polyathlon.ViewModels
{
    public partial class ExerciseKindViewModel : SingleObjectViewModel<ExerciseKind, ExerciseKindViewEntity, long>
    {
        public static ExerciseKindViewModel Create()
        {
            return ViewModelSource.Create(() => new ExerciseKindViewModel());
        }

        protected static ExerciseKindViewEntity CreateNewViewEntity(ExerciseKind region, Flurl.Url request)
        {
            ExerciseKind entity = region with { };
            ExerciseKindViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected ExerciseKindViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}