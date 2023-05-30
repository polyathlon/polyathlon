using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using Region = Polyathlon.Models.Entities.Region;

namespace Polyathlon.ViewModels;

public partial class RegionCollectionViewModel
    : CollectionViewModel<RegionViewEntity, Region>, ISupportParameter
{
    public static RegionCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new RegionCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static RegionViewEntity CreateViewEntity(Region entity, Flurl.Url origin)
    {
        RegionViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected RegionCollectionViewModel() : base(CreateViewEntity)
    {
    }
}