using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using ExerciseKind = Polyathlon.Models.Entities.ExerciseKind;

namespace Polyathlon.ViewModels;

public partial class ExerciseKindCollectionViewModel
    : CollectionViewModel<ExerciseKindViewEntity, ExerciseKind>, ISupportParameter
{
    public static ExerciseKindCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new ExerciseKindCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static ExerciseKindViewEntity CreateViewEntity(ExerciseKind entity, Flurl.Url origin)
    {
        ExerciseKindViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected ExerciseKindCollectionViewModel() : base(CreateViewEntity)
    {
    }
}