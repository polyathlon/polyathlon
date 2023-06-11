using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using Sportsmen = Polyathlon.Models.Entities.Sportsmen;

namespace Polyathlon.ViewModels;

public partial class SportsmenCollectionViewModel
    : CollectionViewModel<SportsmenViewEntity, Sportsmen>, ISupportParameter
{
    public static SportsmenCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new SportsmenCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static SportsmenViewEntity CreateViewEntity(Sportsmen entity, Flurl.Url origin)
    {
        SportsmenViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected SportsmenCollectionViewModel() : base(CreateViewEntity)
    {
    }
}