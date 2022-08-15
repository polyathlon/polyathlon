using System.ComponentModel.DataAnnotations;

namespace Polyathlon.DataModel.Common;

public record class ViewEntityBase<TEntity>
    where TEntity : EntityBase {

    [Display(Name = "Идентификатор", AutoGenerateField = false)]
    public string? Id {
        get => entity.Id;
        set => entity.Id = value;
    }

    [Display(Name = "Ревизия", AutoGenerateField = false)]
    public string? Rev {
        get => entity.Rev;
        set => entity.Rev = value;
    }

    [Display(AutoGenerateField = false)]
    protected readonly TEntity entity;

    [Display(AutoGenerateField = false)]
    public Flurl.Url Origin { get; set; }

    public ViewEntityBase(TEntity entity, string origin) {
        this.entity = entity;
        Origin = origin;
    }
}