using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class SportsmenRelay : EntityBase
{
    public int? Relay { get; set; }
    public int? ClubRelay { get; set; }
    public string? TeamNameRelay { get; set; }
}