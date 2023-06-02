using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class ExerciseNameViewEntity : ViewEntityBase<ExerciseName>
{
    [Display(Name = "Упражнение")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Сокращение упражнения")]
    public string? ShortName
    {
        get => entity.ShortName;
        set => entity.ShortName = value;
    }

    [Display(Name = "Вид упражнения")]
    public string? ExerciseKind
    {
        get => entity.ExerciseKind;
        set => entity.ExerciseKind = value;
    }

    public ExerciseNameViewEntity(ExerciseName exerciseName, Flurl.Url request)
        : base(exerciseName, request)
    {
    }

    public override object Clone()
    {
        ExerciseName entity = this.entity with { };
        ExerciseNameViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}