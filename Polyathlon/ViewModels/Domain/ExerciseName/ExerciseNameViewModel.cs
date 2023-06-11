using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using ExerciseName = Polyathlon.Models.Entities.ExerciseName;

namespace Polyathlon.ViewModels
{
    public partial class ExerciseNameViewModel : SingleObjectViewModel<ExerciseName, ExerciseNameViewEntity, long>
    {
        public static ExerciseNameViewModel Create()
        {
            return ViewModelSource.Create(() => new ExerciseNameViewModel());
        }

        protected static ExerciseNameViewEntity CreateNewViewEntity(ExerciseName region, Flurl.Url request)
        {
            ExerciseName entity = region with { };
            ExerciseNameViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected ExerciseNameViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}