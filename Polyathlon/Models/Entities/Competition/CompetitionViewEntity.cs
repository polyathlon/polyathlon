using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class CompetitionViewEntity : ViewEntityBase<Competition>
{
    [Display(Name = "Вид соревнования")]
    public string? BallTableKind
    {
        get => entity.CompetitionKind;
        set => entity.CompetitionKind = value;
    }

    [Display(Name = "Наименование")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Дата проведения")]
    public string? EventDate
    {
        get => entity.EventDate;
        set => entity.EventDate = value;
    }

    [Display(Name = "Место проведения")]
    public string? EventPlace
    {
        get => entity.EventPlace;
        set => entity.EventPlace = value;
    }

    [Display(Name = "Количество регионов")]
    public int? RegionDelegateNumber
    {
        get => entity.RegionDelegateNumber;
        set => entity.RegionDelegateNumber = value;
    }

    [Display(Name = "Количество клубов")]
    public int? ClubDelegateNumber
    {
        get => entity.ClubDelegateNumber;
        set => entity.ClubDelegateNumber = value;
    }

    [Display(Name = "Логотип")]
    public string? Logotype
    {
        get => entity.Logotype;
        set => entity.Logotype = value;
    }

    [Display(Name = "Язык")]
    public string? Language
    {
        get => entity.Language;
        set => entity.Language = value;
    }

    public CompetitionViewEntity(Competition competition, Flurl.Url request)
        : base(competition, request)
    {
    }

    public override object Clone()
    {
        Competition entity = this.entity with { };
        CompetitionViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}