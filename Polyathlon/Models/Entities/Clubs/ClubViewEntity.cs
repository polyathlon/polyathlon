using System.ComponentModel.DataAnnotations;
using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

public class ClubViewEntity : ViewEntityBase<Club> {

    [Display(Name = "Наименование")]
    public string? Name {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Сокращение")]
    public string? ShortName {
        get => entity.ShortName;
        set => entity.ShortName = value;
    }
    
    [Display(Name = "Команда")]
    public string? RegionName {
        get => entity.Region;
        set => entity.Region = value;
    }

    [Display(Name = "Команда")]
    public string? RegionShortName {
        get => entity.Region;
        set => entity.Region = value;
    }

    public override object Clone() {
        Club entity = this.entity with { };
        ClubViewEntity viewEntity = new(entity, Request);
        return viewEntity;
    }

    public ClubViewEntity(Club region, Flurl.Url request) : base(region, request) {
        
    }
}
