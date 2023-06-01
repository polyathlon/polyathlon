using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class RefereeViewEntity : ViewEntityBase<Referee>
{
    [Display(Name = "ФИО судьи")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Категория судьи")]
    public string? RefereeCategory
    {
        get => entity.RefereeCategory;
        set => entity.RefereeCategory = value;
    }

    [Display(Name = "Населенный пункт судьи")]
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