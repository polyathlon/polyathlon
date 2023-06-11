using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using RefereeBoard = Polyathlon.Models.Entities.RefereeBoard;

namespace Polyathlon.ViewModels;

public partial class RefereeBoardCollectionViewModel
    : CollectionViewModel<RefereeBoardViewEntity, RefereeBoard>, ISupportParameter
{
    public static RefereeBoardCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new RefereeBoardCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static RefereeBoardViewEntity CreateViewEntity(RefereeBoard entity, Flurl.Url origin)
    {
        RefereeBoardViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected RefereeBoardCollectionViewModel() : base(CreateViewEntity)
    {
    }
}