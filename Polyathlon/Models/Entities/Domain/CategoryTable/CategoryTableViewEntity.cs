using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class CategoryTableViewEntity : ViewEntityBase<CategoryTable>
{
    [Display(Name = "Спортивная дисциплина")]
    public string? CompetitionKind
    {
        get => entity.CompetitionKind;
        set => entity.CompetitionKind = value;
    }

    [Display(Name = "Разряд")]
    public string? Category
    {
        get => entity.Category;
        set => entity.Category = value;
    }

    [Display(Name = "Суммарные баллы (мужчины)")]
    public string? BallsMale
    {
        get => entity.BallsMale;
        set => entity.BallsMale = value;
    }

    [Display(Name = "Суммарные баллы (женщины)")]
    public string? BallsFemale
    {
        get => entity.BallsFemale;
        set => entity.BallsFemale = value;
    }

    public CategoryTableViewEntity(CategoryTable categoryTable, Flurl.Url request)
        : base(categoryTable, request)
    {
    }

    public override object Clone()
    {
        CategoryTable entity = this.entity with { };
        CategoryTableViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}