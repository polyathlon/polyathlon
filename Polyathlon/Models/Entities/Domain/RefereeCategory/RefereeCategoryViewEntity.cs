using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class RefereeCategoryViewEntity : ViewEntityBase<RefereeCategory>
{
    [Display(Name = "Наименование")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    public RefereeCategoryViewEntity(RefereeCategory refereeCategory, Flurl.Url request)
        : base(refereeCategory, request)
    {
    }

    public override object Clone()
    {
        RefereeCategory entity = this.entity with { };
        RefereeCategoryViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}