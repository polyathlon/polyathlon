using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class AgeCoefficientViewEntity : ViewEntityBase<AgeCoefficient>
{
    [Display(Name = "Возраст")]
    public int? Age
    {
        get => entity.Age;
        set => entity.Age = value;
    }

    [Display(Name = "Коэффициент")]
    public double? Coefficient
    {
        get => entity.Coefficient;
        set => entity.Coefficient = value;
    }

    [Display(Name = "Соревнование")]
    public string? CompetitionId
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    public AgeCoefficientViewEntity(AgeCoefficient ageCoefficient, Flurl.Url request)
        : base(ageCoefficient, request)
    {
    }

    public override object Clone()
    {
        AgeCoefficient entity = this.entity with { };
        AgeCoefficientViewEntity viewEntity = new(entity, Request);
        return viewEntity;
    }
}