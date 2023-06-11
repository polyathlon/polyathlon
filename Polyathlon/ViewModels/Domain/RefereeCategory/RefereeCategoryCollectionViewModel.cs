using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using RefereeCategory = Polyathlon.Models.Entities.RefereeCategory;

namespace Polyathlon.ViewModels;

public partial class RefereeCategoryCollectionViewModel
    : CollectionViewModel<RefereeCategoryViewEntity, RefereeCategory>, ISupportParameter
{
    public static RefereeCategoryCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new RefereeCategoryCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static RefereeCategoryViewEntity CreateViewEntity(RefereeCategory entity, Flurl.Url origin)
    {
        RefereeCategoryViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected RefereeCategoryCollectionViewModel() : base(CreateViewEntity)
    {
    }
}