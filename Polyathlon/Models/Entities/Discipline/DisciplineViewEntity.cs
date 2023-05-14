using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class DisciplineViewEntity : ViewEntityBase<Discipline>
{
    [Display(Name = "Соревнование")]
    public string? Competition
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    [Display(Name = "Возрастная группа")]
    public string? AgeGroup
    {
        get => entity.AgeGroup;
        set => entity.AgeGroup = value;
    }

    [Display(Name = "Дисциплина")]
    public string? DisciplineName
    {
        get => entity.DiscplineName;
        set => entity.DiscplineName = value;
    }

    public DisciplineViewEntity(Discipline discipline, Flurl.Url request)
        : base(discipline, request)
    {
    }

    public override object Clone()
    {
        Discipline entity = this.entity with { };
        DisciplineViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}