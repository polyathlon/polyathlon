using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class AgeCoefficientViewEntity : ViewEntityBase<AgeCoefficient>
{
    [Display(Name = "Возраст")]
    public string? Age
    {
        get => entity.Age;
        set => entity.Age = value;
    }

    [Display(Name = "Коэффициент")]
    public string? Coefficient
    {
        get => entity.Coefficient;
        set => entity.Coefficient = value;
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