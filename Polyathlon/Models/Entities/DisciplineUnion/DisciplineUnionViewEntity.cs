using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class DisciplineUnionViewEntity : ViewEntityBase<DisciplineUnion>
{
    [Display(Name = "Объединение")]
    public string? Union
    {
        get => entity.Union;
        set => entity.Union = value;
    }

    [Display(Name = "Дисциплина")]
    public string? Discipline
    {
        get => entity.Discipline;
        set => entity.Discipline = value;
    }

    public DisciplineUnionViewEntity(DisciplineUnion disciplineUnion, Flurl.Url request)
        : base(disciplineUnion, request)
    {
    }

    public override object Clone()
    {
        DisciplineUnion entity = this.entity with { };
        DisciplineUnionViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}