using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class TeamNameRelayViewEntity : ViewEntityBase<TeamNameRelay>
{
    [Display(Name = "Наименование")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Соревнование")]
    public string? ShortName
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    public TeamNameRelayViewEntity(TeamNameRelay teamNameRelay, Flurl.Url request)
        : base(teamNameRelay, request)
    {
    }

    public override object Clone()
    {
        TeamNameRelay entity = this.entity with { };
        TeamNameRelayViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}