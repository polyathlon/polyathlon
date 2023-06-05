using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class SportsmenViewEntity : ViewEntityBase<Sportsmen>
{
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
    public string? BirthYear
    {
        get => entity.BirthYear;
        set => entity.BirthYear = value;
    }

    [Display(Name = "Разряд")]
    public string? Category
    {
        get => entity.Category;
        set => entity.Category = value;
    }

    [Display(Name = "Спортивный клуб")]
    public string? Club
    {
        get => entity.Club;
        set => entity.Club = value;
    }

    [Display(Name = "Номер спортсмена")]
    public string? SportsmenNumber
    {
        get => entity.SportsmenNumber;
        set => entity.SportsmenNumber = value;
    }

    [Display(Name = "Количество команд")]
    public string? RegionDelegate
    {
        get => entity.RegionDelegate;
        set => entity.RegionDelegate = value;
    }

    [Display(Name = "Количество клубов")]
    public string? ClubDelegate
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
    public string? Place
    {
        get => entity.Place;
        set => entity.Place = value;
    }

    [Display(Name = "Очки")]
    public string? Balls
    {
        get => entity.Balls;
        set => entity.Balls = value;
    }

    [Display(Name = "Новый разряд")]
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
    public string? IsActive
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