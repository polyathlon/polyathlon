using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class ExerciseNameViewEntity : ViewEntityBase<ExerciseName>
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

    [Display(Name = "Вид дисциплины")]
    public string? DisciplineKind
    {
        get => entity.DisciplineKind;
        set => entity.DisciplineKind = value;
    }

    public ExerciseNameViewEntity(ExerciseName disciplineName, Flurl.Url request)
        : base(disciplineName, request)
    {
    }

    public override object Clone()
    {
        ExerciseName entity = this.entity with { };
        ExerciseNameViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}