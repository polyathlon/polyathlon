using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using ThrowResult = Polyathlon.Models.Entities.ThrowResult;

namespace Polyathlon.ViewModels;

public partial class ThrowResultCollectionViewModel
    : CollectionViewModel<ThrowResultViewEntity, ThrowResult>, ISupportParameter
{
    public static ThrowResultCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new ThrowResultCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static ThrowResultViewEntity CreateViewEntity(ThrowResult entity, Flurl.Url origin)
    {
        ThrowResultViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected ThrowResultCollectionViewModel() : base(CreateViewEntity)
    {
    }
}