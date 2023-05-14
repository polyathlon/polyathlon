using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class SportsmenResultViewEntity : ViewEntityBase<SportsmenResult>
{
    [Display(Name = "Спортсмен")]
    public string? Sportsmen
    {
        get => entity.Sportsmen;
        set => entity.Sportsmen = value;
    }

    [Display(Name = "Название дисциплины")]
    public string? DisciplineName
    {
        get => entity.DisciplineName;
        set => entity.DisciplineName = value;
    }

    [Display(Name = "Результат")]
    public string? Result
    {
        get => entity.Result;
        set => entity.Result = value;
    }

    [Display(Name = "Баллы")]
    public int? Balls
    {
        get => entity.Balls;
        set => entity.Balls = value;
    }

    [Display(Name = "Информация")]
    public int? Info
    {
        get => entity.Info;
        set => entity.Info = value;
    }

    [Display(Name = "Дорожка")]
    public string? Road
    {
        get => entity.Road;
        set => entity.Road = value;
    }

    [Display(Name = "Место")]
    public int? Place
    {
        get => entity.Place;
        set => entity.Place = value;
    }

    [Display(Name = "Примечание")]
    public string? Note
    {
        get => entity.Note;
        set => entity.Note = value;
    }

    [Display(Name = "BestResult")]
    public string? BestResult
    {
        get => entity.BestResult;
        set => entity.BestResult = value;
    }

    [Display(Name = "Комментарий")]
    public string? Comment
    {
        get => entity.Comment;
        set => entity.Comment = value;
    }

    [Display(Name = "Текущий номер")]
    public int? CurrentNumber
    {
        get => entity.CurrentNumber;
        set => entity.CurrentNumber = value;
    }

    public SportsmenResultViewEntity(SportsmenResult sportsmenResult, Flurl.Url request)
        : base(sportsmenResult, request)
    {
    }

    public override object Clone()
    {
        SportsmenResult entity = this.entity with { };
        SportsmenResultViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}