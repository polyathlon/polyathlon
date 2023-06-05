using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class ExerciseViewEntity : ViewEntityBase<Exercise>
{
    [Display(Name = "Возрастная группа")]
    public string? AgeGroup
    {
        get => entity.AgeGroup;
        set => entity.AgeGroup = value;
    }

    [Display(Name = "Упраженение")]
    public string? DisciplineName
    {
        get => entity.DiscplineName;
        set => entity.DiscplineName = value;
    }

    public ExerciseViewEntity(Exercise exercise, Flurl.Url request)
        : base(exercise, request)
    {
    }

    public override object Clone()
    {
        Exercise entity = this.entity with { };
        ExerciseViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}