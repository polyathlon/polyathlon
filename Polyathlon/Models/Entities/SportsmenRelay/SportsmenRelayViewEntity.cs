using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class SportsmenRelayViewEntity : ViewEntityBase<SportsmenRelay>
{
    [Display(Name = "Наименование")]
    public string? TeamNameRelay
    {
        get => entity.TeamNameRelay;
        set => entity.TeamNameRelay = value;
    }

    [Display(Name = "")]
    public int? Relay
    {
        get => entity.Relay;
        set => entity.Relay = value;
    }

    [Display(Name = "")]
    public int? ClubRelay
    {
        get => entity.ClubRelay;
        set => entity.ClubRelay = value;
    }

    public SportsmenRelayViewEntity(SportsmenRelay sportsmenRelay, Flurl.Url request)
        : base(sportsmenRelay, request)
    {
    }

    public override object Clone()
    {
        SportsmenRelay entity = this.entity with { };
        SportsmenRelayViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}