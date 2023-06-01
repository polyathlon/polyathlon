using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

public class RegionViewEntity : ViewEntityBase<Region>
{
    [Display(Name = "Субъект РФ")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Сокращение субъекта РФ")]
    public string? ShortName
    {
        get => entity.ShortName;
        set => entity.ShortName = value;
    }

    public RegionViewEntity(Region region, Flurl.Url request)
        : base(region, request)
    {
    }

    public override object Clone()
    {
        Region entity = this.entity with { };
        RegionViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}