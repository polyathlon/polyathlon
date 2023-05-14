using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class CategoryTableViewEntity : ViewEntityBase<CategoryTable>
{
    [Display(Name = "Вид соревнования")]
    public string? CompetitionKind
    {
        get => entity.CompetitionKind;
        set => entity.CompetitionKind = value;
    }

    [Display(Name = "Категория")]
    public string? Category
    {
        get => entity.Category;
        set => entity.Category = value;
    }

    [Display(Name = "Баллы")]
    public int? Balls
    {
        get => entity.Balls;
        set => entity.Balls = value;
    }

    [Display(Name = "Баллы для выигрыша")]
    public int? BallsW
    {
        get => entity.BallsW;
        set => entity.BallsW = value;
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