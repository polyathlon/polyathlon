using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class CategoryViewEntity : ViewEntityBase<Category>
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

    [Display(Name = "Минимальные баллы")]
    public int? MinBalls
    {
        get => entity.MinBalls;
        set => entity.MinBalls = value;
    }

    [Display(Name = "Минимальные баллы для выигрыша")]
    public int? MinBallsW
    {
        get => entity.MinBallsW;
        set => entity.MinBallsW = value;
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