using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class UnionFinishkaViewEntity : ViewEntityBase<UnionFinishka>
{
    [Display(Name = "Объединение")]
    public string? Union
    {
        get => entity.Union;
        set => entity.Union = value;
    }

    [Display(Name = "Время финиша")]
    public string? FinishTime
    {
        get => entity.FinishTime;
        set => entity.FinishTime = value;
    }

    [Display(Name = "Номер спортсмена")]
    public int? SportsmenNumber
    {
        get => entity.SportsmenNumber;
        set => entity.SportsmenNumber = value;
    }

    public UnionFinishkaViewEntity(UnionFinishka unionFinishka, Flurl.Url request)
        : base(unionFinishka, request)
    {
    }

    public override object Clone()
    {
        UnionFinishka entity = this.entity with { };
        UnionFinishkaViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}