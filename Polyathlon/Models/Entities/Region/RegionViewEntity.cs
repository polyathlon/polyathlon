using System.ComponentModel.DataAnnotations;
using Polyathlon.DataModel.Common;

namespace Polyathlon.DataModel.Entities;

public class RegionViewEntity : ViewEntityBase<Region> {

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

    public RegionViewEntity(Region region, string origin) : base(region, origin) {
        
    }
}
