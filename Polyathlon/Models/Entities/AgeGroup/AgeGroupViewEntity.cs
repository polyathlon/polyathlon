using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class AgeGroupViewEntity : ViewEntityBase<AgeGroup>
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

    [Display(Name = "Минимальный возраст")]
    public int? MinAge
    {
        get => entity.MinAge;
        set => entity.MinAge = value;
    }

    [Display(Name = "Максимальный возраст")]
    public int? MaxAge
    {
        get => entity.MaxAge;
        set => entity.MaxAge = value;
    }

    [Display(Name = "Сортировка")]
    public int? SortOrder
    {
        get => entity.SortOrder;
        set => entity.SortOrder = value;
    }

    [Display(Name = "Пол")]
    public string? Gender
    {
        get => entity.Gender;
        set => entity.Gender = value;
    }

    [Display(Name = "Соревнование")]
    public string? Competition
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    public AgeGroupViewEntity(AgeGroup ageGroup, Flurl.Url request)
        : base(ageGroup, request)
    {
    }

    public override object Clone()
    {
        AgeGroup entity = this.entity with { };
        AgeGroupViewEntity viewEntity = new(entity, Request);
        return viewEntity;
    }
}