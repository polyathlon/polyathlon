using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using ExerciseName = Polyathlon.Models.Entities.ExerciseName;

namespace Polyathlon.ViewModels;

public partial class ExerciseNameCollectionViewModel
    : CollectionViewModel<ExerciseNameViewEntity, ExerciseName>, ISupportParameter
{
    public static ExerciseNameCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new ExerciseNameCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static ExerciseNameViewEntity CreateViewEntity(ExerciseName entity, Flurl.Url origin)
    {
        ExerciseNameViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected ExerciseNameCollectionViewModel() : base(CreateViewEntity)
    {
    }
}