using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class RefereeViewEntity : ViewEntityBase<Referee>
{
    [Display(Name = "Имя")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Категория")]
    public string? RefereeCategory
    {
        get => entity.RefereeCategory;
        set => entity.RefereeCategory = value;
    }

    [Display(Name = "Город")]
    public string? RefereeCity
    {
        get => entity.RefereeCity;
        set => entity.RefereeCity = value;
    }

    public RefereeViewEntity(Referee referee, Flurl.Url request)
        : base(referee, request)
    {
    }

    public override object Clone()
    {
        Referee entity = this.entity with { };
        RefereeViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}