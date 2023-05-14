using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class SportsmenViewEntity : ViewEntityBase<Sportsmen>
{
    [Display(Name = "Соревнование")]
    public string? Competition
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    [Display(Name = "Имя")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Пол")]
    public string? Gender
    {
        get => entity.Gender;
        set => entity.Gender = value;
    }

    [Display(Name = "Год рождения")]
    public int? BirthYear
    {
        get => entity.BirthYear;
        set => entity.BirthYear = value;
    }

    [Display(Name = "Категория")]
    public string? Category
    {
        get => entity.Category;
        set => entity.Category = value;
    }

    [Display(Name = "Клуб")]
    public string? Club
    {
        get => entity.Club;
        set => entity.Club = value;
    }

    [Display(Name = "Номер спортсмена")]
    public int? SportsmenNumber
    {
        get => entity.SportsmenNumber;
        set => entity.SportsmenNumber = value;
    }

    [Display(Name = "Количество регионов")]
    public int? RegionDelegate
    {
        get => entity.RegionDelegate;
        set => entity.RegionDelegate = value;
    }

    [Display(Name = "Количество клубов")]
    public int? ClubDelegate
    {
        get => entity.ClubDelegate;
        set => entity.ClubDelegate = value;
    }

    [Display(Name = "Возрастная группа")]
    public string? AgeGroup
    {
        get => entity.AgeGroup;
        set => entity.AgeGroup = value;
    }

    [Display(Name = "Место")]
    public int? Place
    {
        get => entity.Place;
        set => entity.Place = value;
    }

    [Display(Name = "Баллы")]
    public int? Balls
    {
        get => entity.Balls;
        set => entity.Balls = value;
    }

    [Display(Name = "Новая категория")]
    public string? SetCategory
    {
        get => entity.SetCategory;
        set => entity.SetCategory = value;
    }

    [Display(Name = "Лучший результат в спринте")]
    public string? BestResultSprint
    {
        get => entity.BestResultSprint;
        set => entity.BestResultSprint = value;
    }

    [Display(Name = "Лучший результат в плавании")]
    public string? BestResultSwimmer
    {
        get => entity.BestResultSwimmer;
        set => entity.BestResultSwimmer = value;
    }

    [Display(Name = "Активный")]
    public int? IsActive
    {
        get => entity.IsActive;
        set => entity.IsActive = value;
    }

    public SportsmenViewEntity(Sportsmen sportsmen, Flurl.Url request)
        : base(sportsmen, request)
    {
    }

    public override object Clone()
    {
        Sportsmen entity = this.entity with { };
        SportsmenViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}