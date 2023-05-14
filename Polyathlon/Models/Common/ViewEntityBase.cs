using System.ComponentModel.DataAnnotations;

namespace Polyathlon.Models.Common;

public abstract class ViewEntityBase<TEntity>
    : ICloneable
    where TEntity : EntityBase
{
    [Display(Name = "Идентификатор", AutoGenerateField = false)]
    public string? Id
    {
        get => entity.Id;
        set => entity.Id = value;
    }

    [Display(Name = "Ревизия", AutoGenerateField = false)]
    public string? Rev
    {
        get => entity.Rev;
        set => entity.Rev = value;
    }

    [Display(AutoGenerateField = false)]
    protected TEntity entity;

    [Display(AutoGenerateField = false)]
    public TEntity Entity
    {
        get => entity;
        set => entity = value;
    }

    [Display(AutoGenerateField = false)]
    public Flurl.Url Request { get; set; }

    public ViewEntityBase(TEntity entity, Flurl.Url request)
    {
        this.entity = entity;
        Request = request;
    }

    public abstract object Clone();
}