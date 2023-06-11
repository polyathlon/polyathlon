using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using Exercise = Polyathlon.Models.Entities.Exercise;

namespace Polyathlon.ViewModels;

public partial class ExerciseCollectionViewModel
    : CollectionViewModel<ExerciseViewEntity, Exercise>, ISupportParameter
{
    public static ExerciseCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new ExerciseCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static ExerciseViewEntity CreateViewEntity(Exercise entity, Flurl.Url origin)
    {
        ExerciseViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected ExerciseCollectionViewModel() : base(CreateViewEntity)
    {
    }
}