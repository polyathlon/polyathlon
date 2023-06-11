using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class CategoriesTableTableViewEntity : ViewEntityBase<CategoriesTable>
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

    public CategoriesTableTableViewEntity(CategoriesTable categoryTable, Flurl.Url request)
        : base(categoryTable, request)
    {
    }

    public override object Clone()
    {
        CategoriesTable entity = this.entity with { };
        CategoriesTableTableViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}