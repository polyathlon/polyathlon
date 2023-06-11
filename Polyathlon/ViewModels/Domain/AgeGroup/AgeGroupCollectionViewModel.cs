using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using AgeGroup = Polyathlon.Models.Entities.AgeGroup;

namespace Polyathlon.ViewModels;

public partial class AgeGroupCollectionViewModel
    : CollectionViewModel<AgeGroupViewEntity, AgeGroup>, ISupportParameter
{
    public static AgeGroupCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new AgeGroupCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static AgeGroupViewEntity CreateViewEntity(AgeGroup entity, Flurl.Url origin)
    {
        AgeGroupViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected AgeGroupCollectionViewModel() : base(CreateViewEntity)
    {
    }
}