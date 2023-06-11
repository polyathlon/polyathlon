using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using Referee = Polyathlon.Models.Entities.Referee;

namespace Polyathlon.ViewModels;

public partial class RefereeCollectionViewModel
    : CollectionViewModel<RefereeViewEntity, Referee>, ISupportParameter
{
    public static RefereeCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new RefereeCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static RefereeViewEntity CreateViewEntity(Referee entity, Flurl.Url origin)
    {
        RefereeViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected RefereeCollectionViewModel() : base(CreateViewEntity)
    {
    }
}