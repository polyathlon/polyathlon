using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using RefereePosition = Polyathlon.Models.Entities.RefereePosition;

namespace Polyathlon.ViewModels;

public partial class RefereePositionCollectionViewModel
    : CollectionViewModel<RefereePositionViewEntity, RefereePosition>, ISupportParameter
{
    public static RefereePositionCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new RefereePositionCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static RefereePositionViewEntity CreateViewEntity(RefereePosition entity, Flurl.Url origin)
    {
        RefereePositionViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected RefereePositionCollectionViewModel() : base(CreateViewEntity)
    {
    }
}