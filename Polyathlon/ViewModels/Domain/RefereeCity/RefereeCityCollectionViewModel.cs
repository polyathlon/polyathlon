using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using RefereeCity = Polyathlon.Models.Entities.RefereeCity;

namespace Polyathlon.ViewModels;

public partial class RefereeCityCollectionViewModel
    : CollectionViewModel<RefereeCityViewEntity, RefereeCity>, ISupportParameter
{
    public static RefereeCityCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new RefereeCityCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static RefereeCityViewEntity CreateViewEntity(RefereeCity entity, Flurl.Url origin)
    {
        RefereeCityViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected RefereeCityCollectionViewModel() : base(CreateViewEntity)
    {
    }
}