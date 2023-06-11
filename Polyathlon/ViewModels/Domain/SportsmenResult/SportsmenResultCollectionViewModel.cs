using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using SportsmenResult = Polyathlon.Models.Entities.SportsmenResult;

namespace Polyathlon.ViewModels;

public partial class SportsmenResultCollectionViewModel
    : CollectionViewModel<SportsmenResultViewEntity, SportsmenResult>, ISupportParameter
{
    public static SportsmenResultCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new SportsmenResultCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static SportsmenResultViewEntity CreateViewEntity(SportsmenResult entity, Flurl.Url origin)
    {
        SportsmenResultViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected SportsmenResultCollectionViewModel() : base(CreateViewEntity)
    {
    }
}