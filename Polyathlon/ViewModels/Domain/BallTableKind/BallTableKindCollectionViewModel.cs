using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using BallTableKind = Polyathlon.Models.Entities.BallTableKind;

namespace Polyathlon.ViewModels;

public partial class BallTableKindCollectionViewModel
    : CollectionViewModel<BallTableKindViewEntity, BallTableKind>, ISupportParameter
{
    public static BallTableKindCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new BallTableKindCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static BallTableKindViewEntity CreateViewEntity(BallTableKind entity, Flurl.Url origin)
    {
        BallTableKindViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected BallTableKindCollectionViewModel() : base(CreateViewEntity)
    {
    }
}