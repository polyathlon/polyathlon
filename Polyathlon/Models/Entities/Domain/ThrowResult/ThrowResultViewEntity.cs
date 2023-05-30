using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class ThrowResultViewEntity : ViewEntityBase<ThrowResult>
{
    [Display(Name = "Спортсмен")]
    public string? Sportsmen
    {
        get => entity.Sportsmen;
        set => entity.Sportsmen = value;
    }

    [Display(Name = "Попытка 1")]
    public string? Try1
    {
        get => entity.Try1;
        set => entity.Try1 = value;
    }

    [Display(Name = "Попытка 2")]
    public string? Try2
    {
        get => entity.Try2;
        set => entity.Try3 = value;
    }

    [Display(Name = "Попытка 3")]
    public string? Try3
    {
        get => entity.Try3;
        set => entity.Try3 = value;
    }

    public ThrowResultViewEntity(ThrowResult throwResult, Flurl.Url request)
        : base(throwResult, request)
    {
    }

    public override object Clone()
    {
        ThrowResult entity = this.entity with { };
        ThrowResultViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}