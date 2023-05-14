using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class UnionViewEntity : ViewEntityBase<Union>
{
    [Display(Name = "Наименование")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Соревнование")]
    public string? Competition
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    [Display(Name = "Вид дисциплины")]
    public string? DisciplineKind
    {
        get => entity.DisciplineKind;
        set => entity.DisciplineKind = value;
    }

    public UnionViewEntity(Union union, Flurl.Url request)
        : base(union, request)
    {
    }

    public override object Clone()
    {
        Union entity = this.entity with { };
        UnionViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}