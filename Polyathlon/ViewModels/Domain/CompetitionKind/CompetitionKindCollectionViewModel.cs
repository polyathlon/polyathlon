using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using CompetitionKind = Polyathlon.Models.Entities.CompetitionKind;

namespace Polyathlon.ViewModels;

public partial class CompetitionKindCollectionViewModel
    : CollectionViewModel<CompetitionKindViewEntity, CompetitionKind>, ISupportParameter
{
    public static CompetitionKindCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new CompetitionKindCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static CompetitionKindViewEntity CreateViewEntity(CompetitionKind entity, Flurl.Url origin)
    {
        CompetitionKindViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected CompetitionKindCollectionViewModel() : base(CreateViewEntity)
    {
    }
}