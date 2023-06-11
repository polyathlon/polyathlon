using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using Competition = Polyathlon.Models.Entities.Competition;

namespace Polyathlon.ViewModels;

public partial class CompetitionCollectionViewModel
    : CollectionViewModel<CompetitionViewEntity, Competition>, ISupportParameter
{
    public static CompetitionCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new CompetitionCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static CompetitionViewEntity CreateViewEntity(Competition entity, Flurl.Url origin)
    {
        CompetitionViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected CompetitionCollectionViewModel() : base(CreateViewEntity)
    {
    }
}