using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class SportsmenRelayResultViewEntity : ViewEntityBase<SportsmenRelayResult>
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

    [Display(Name = "Начальные баллы")]
    public int? StartBalls
    {
        get => entity.StartBalls;
        set => entity.StartBalls = value;
    }

    [Display(Name = "Суммарные баллы")]
    public int? SumBalls
    {
        get => entity.SumBalls;
        set => entity.SumBalls = value;
    }

    [Display(Name = "Суммарное место")]
    public int? SumPlace
    {
        get => entity.SumPlace;
        set => entity.SumPlace = value;
    }

    [Display(Name = "Суммарный результат")]
    public string? SumResult
    {
        get => entity.SumResult;
        set => entity.SumResult = value;
    }

    [Display(Name = "Результат лыжи")]
    public string? SkiResult
    {
        get => entity.SumResult;
        set => entity.SkiResult = value;
    }

    [Display(Name = "Баллы лыжи")]
    public int? SkiBalls
    {
        get => entity.SkiBalls;
        set => entity.SkiBalls = value;
    }

    [Display(Name = "Инфо лыжи")]
    public int? SkiInfo
    {
        get => entity.SkiInfo;
        set => entity.SkiInfo = value;
    }

    [Display(Name = "Дорожка лыжи")]
    public string? SkiRoad
    {
        get => entity.SkiRoad;
        set => entity.SkiRoad = value;
    }

    [Display(Name = "Место лыжи")]
    public int? SkiPlace
    {
        get => entity.SkiPlace;
        set => entity.SkiPlace = value;
    }

    [Display(Name = "Примечание лыжи")]
    public string? SkiNote
    {
        get => entity.SkiNote;
        set => entity.SkiNote = value;
    }

    [Display(Name = "Лучший результат лыжи")]
    public string? SkiBestResult
    {
        get => entity.SkiBestResult;
        set => entity.SkiBestResult = value;
    }

    [Display(Name = "Комментарий лыжи")]
    public string? SkiComment
    {
        get => entity.SkiComment;
        set => entity.SkiComment = value;
    }

    [Display(Name = "Текущий номер лыжи")]
    public int? SkiCurrentNumber
    {
        get => entity.SkiCurrentNumber;
        set => entity.SkiCurrentNumber = value;
    }

    [Display(Name = "Стартовый номер лыжи")]
    public int? SkiStartNumber
    {
        get => entity.SkiStartNumber;
        set => entity.SkiStartNumber = value;
    }

    [Display(Name = "Суммарный балл лыжи")]
    public int? SkiSumBalls
    {
        get => entity.SkiSumBalls;
        set => entity.SkiSumBalls = value;
    }

    [Display(Name = "Суммарное место лыжи")]
    public int? SkiSumPlace
    {
        get => entity.SkiSumPlace;
        set => entity.SkiSumPlace = value;
    }

    [Display(Name = "Суммарный результат лыжи")]
    public string? SkiSumResult
    {
        get => entity.SkiSumResult;
        set => entity.SkiSumResult = value;
    }

    public SportsmenRelayResultViewEntity(SportsmenRelayResult sportsmenRelayResult, Flurl.Url request)
        : base(sportsmenRelayResult, request)
    {
    }

    public override object Clone()
    {
        SportsmenRelayResult entity = this.entity with { };
        SportsmenRelayResultViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}