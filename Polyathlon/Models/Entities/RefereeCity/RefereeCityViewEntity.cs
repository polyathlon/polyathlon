using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class RefereeCityViewEntity : ViewEntityBase<RefereeCity>
{
    [Display(Name = "Наименование")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    public RefereeCityViewEntity(RefereeCity refereeCity, Flurl.Url request)
        : base(refereeCity, request)
    {
    }

    public override object Clone()
    {
        RefereeCity entity = this.entity with { };
        RefereeCityViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}