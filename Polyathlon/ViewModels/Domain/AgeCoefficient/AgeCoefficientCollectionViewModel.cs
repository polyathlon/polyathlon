using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using AgeCoefficient = Polyathlon.Models.Entities.AgeCoefficient;

namespace Polyathlon.ViewModels;

public partial class AgeCoefficientCollectionViewModel
    : CollectionViewModel<AgeCoefficientViewEntity, AgeCoefficient>, ISupportParameter
{
    public static AgeCoefficientCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new AgeCoefficientCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static AgeCoefficientViewEntity CreateViewEntity(AgeCoefficient entity, Flurl.Url origin)
    {
        AgeCoefficientViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected AgeCoefficientCollectionViewModel() : base(CreateViewEntity)
    {
    }
}