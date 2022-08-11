using System.ComponentModel.DataAnnotations;

namespace Polyathlon.DataModel.Common;

public record class ViewEntityBase<TEntity> {
    [Display(AutoGenerateField = false)]
    protected readonly TEntity entity;

    [Display(AutoGenerateField = false)]
    public string Origin { get; set; }

    public ViewEntityBase(TEntity entity, string origin) {
        this.entity = entity;
        Origin = origin;
    }
    public ViewEntityBase() {
        
    }
}