using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Exercise = Polyathlon.Models.Entities.Exercise;

namespace Polyathlon.ViewModels
{
    public partial class ExerciseViewModel : SingleObjectViewModel<Exercise, ExerciseViewEntity, long>
    {
        public static ExerciseViewModel Create()
        {
            return ViewModelSource.Create(() => new ExerciseViewModel());
        }

        protected static ExerciseViewEntity CreateNewViewEntity(Exercise region, Flurl.Url request)
        {
            Exercise entity = region with { };
            ExerciseViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected ExerciseViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}