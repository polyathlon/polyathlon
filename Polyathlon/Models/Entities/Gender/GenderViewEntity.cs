using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class GenderViewEntity : ViewEntityBase<Gender>
{
    [Display(Name = "Наименование")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Сокращение")]
    public string? ShortName
    {
        get => entity.ShortName;
        set => entity.ShortName = value;
    }

    public GenderViewEntity(Gender gender, Flurl.Url request)
        : base(gender, request)
    {
    }

    public override object Clone()
    {
        Gender entity = this.entity with { };
        GenderViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}