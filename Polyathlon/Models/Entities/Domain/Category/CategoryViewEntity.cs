using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class CategoryViewEntity : ViewEntityBase<Category>
{
    [Display(Name = "Разряд")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Сокращение разряда")]
    public string? ShortNameRoman
    {
        get => entity.ShortNameRoman;
        set => entity.ShortNameRoman = value;
    }

    [Display(Name = "Сокращение разряда")]
    public string? ShortNameArabic
    {
        get => entity.ShortNameArabic;
        set => entity.ShortNameArabic = value;
    }

    [Display(Name = "Минимальные баллы (мужчины)")]
    public string? MinBallsMale
    {
        get => entity.MinBallsMale;
        set => entity.MinBallsMale = value;
    }

    [Display(Name = "Минимальные баллы (женщины)")]
    public string? MinBallsFemale
    {
        get => entity.MinBallsFemale;
        set => entity.MinBallsFemale = value;
    }

    public CategoryViewEntity(Category category, Flurl.Url request)
        : base(category, request)
    {
    }

    public override object Clone()
    {
        Category entity = this.entity with { };
        CategoryViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}