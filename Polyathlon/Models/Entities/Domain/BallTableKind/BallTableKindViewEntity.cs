using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class BallTableKindViewEntity : ViewEntityBase<BallTableKind>
{
    [Display(Name = "Упражнение")]
    public string? ExerciseName
    {
        get => entity.ExerciseName;
        set => entity.ExerciseName = value;
    }

    [Display(Name = "Пол")]
    public string? Gender
    {
        get => entity.Gender;
        set => entity.Gender = value;
    }

    [Display(Name = "Минимальный возраст")]
    public string? MinAge
    {
        get => entity.MinAge;
        set => entity.MinAge = value;
    }

    [Display(Name = "Максимальный возраст")]
    public string? MaxAge
    {
        get => entity.MaxAge;
        set => entity.MaxAge = value;
    }

    public BallTableKindViewEntity(BallTableKind ballTableKind, Flurl.Url request)
        : base(ballTableKind, request)
    {
    }

    public override object Clone()
    {
        BallTableKind entity = this.entity with { };
        BallTableKindViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}