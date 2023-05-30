using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class RefereePositionViewEntity : ViewEntityBase<RefereePosition>
{
    [Display(Name = "Наименование")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    public RefereePositionViewEntity(RefereePosition refereePosition, Flurl.Url request)
        : base(refereePosition, request)
    {
    }

    public override object Clone()
    {
        RefereePosition entity = this.entity with { };
        RefereePositionViewEntity viewEntity = new(entity, Request);
        return viewEntity;
    }
}