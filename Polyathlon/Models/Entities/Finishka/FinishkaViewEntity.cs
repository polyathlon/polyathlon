using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class FinishkaViewEntity : ViewEntityBase<Finishka>
{
    [Display(Name = "Соревнование")]
    public string? Competition
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    [Display(Name = "Название дисциплины")]
    public string? DisciplineName
    {
        get => entity.DisciplineName;
        set => entity.DisciplineName = value;
    }

    [Display(Name = "Пол")]
    public string? Gender
    {
        get => entity.Gender;
        set => entity.Gender = value;
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

    public FinishkaViewEntity(Finishka finishka, Flurl.Url request)
        : base(finishka, request)
    {
    }

    public override object Clone()
    {
        Finishka entity = this.entity with { };
        FinishkaViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}