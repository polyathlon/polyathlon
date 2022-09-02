using System.ComponentModel.DataAnnotations;
using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

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
        get => ModuleDatabase.ModuleDb.GetViewEntities<RegionViewEntity>("module:01GA69CF93RKFMC2EA07EZ4YHY", entity.Region).Name;
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
