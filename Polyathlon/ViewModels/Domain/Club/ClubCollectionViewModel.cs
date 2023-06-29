using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

namespace Polyathlon.ViewModels;

public class ClubCollectionViewModel
    : CollectionViewModel<ClubViewEntity, Club>, ISupportParameter
{
    public override bool IsLoading { get; protected set; } = false;

    protected ClubCollectionViewModel() : base(CreateViewEntity)
    {
    }

    public static ClubCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new ClubCollectionViewModel());
    }

    protected static ClubViewEntity CreateViewEntity(Club entity, Flurl.Url origin)
    {
        ClubViewEntity viewEntity = new(entity, origin);
        return viewEntity;
    }
}