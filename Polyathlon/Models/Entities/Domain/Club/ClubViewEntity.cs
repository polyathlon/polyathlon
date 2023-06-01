using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class ClubViewEntity : ViewEntityBase<Club>
{
    [Display(Name = "Спортивный клуб")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Субъект РФ")]
    public string? RegionName
    {
        get => ModuleDatabase.ModuleDb
            .GetViewEntities<RegionViewEntity>("module:01GA69CF93RKFMC2EA07EZ4YHY", entity.Region).Name;
        set => entity.Region = value;
    }

    [Display(Name = "Сокращение Субъекта РФ")]
    public string? RegionShortName
    {
        get =>
            ModuleDatabase.ModuleDb
            .GetViewEntities<RegionViewEntity>("module:01GA69CF93RKFMC2EA07EZ4YHY", entity.Region).ShortName;
        set => entity.Region = value;
    }

    public ClubViewEntity(Club club, Flurl.Url request)
        : base(club, request)
    {
    }

    public override object Clone()
    {
        Club entity = this.entity with { };
        ClubViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}