using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using BallTable = Polyathlon.Models.Entities.BallTable;

namespace Polyathlon.ViewModels;

public partial class BallTableCollectionViewModel
    : CollectionViewModel<BallTableViewEntity, BallTable>, ISupportParameter
{
    public static BallTableCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new BallTableCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static BallTableViewEntity CreateViewEntity(BallTable entity, Flurl.Url origin)
    {
        BallTableViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected BallTableCollectionViewModel() : base(CreateViewEntity)
    {
    }
}