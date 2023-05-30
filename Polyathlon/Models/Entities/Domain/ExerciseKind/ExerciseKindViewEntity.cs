using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class ExerciseKindViewEntity : ViewEntityBase<ExerciseKind>
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

    public ExerciseKindViewEntity(ExerciseKind disciplineKind, Flurl.Url request)
        : base(disciplineKind, request)
    {
    }

    public override object Clone()
    {
        ExerciseKind entity = this.entity with { };
        ExerciseKindViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}