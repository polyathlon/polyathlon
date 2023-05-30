using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Competition : EntityBase
{
    public string? CompetitionKind { get; set; }
    public string? Name { get; set; }
    public string? EventDate { get; set; }
    public string? EventPlace { get; set; }
    public int? RegionDelegateNumber { get; set; }
    public int? Year { get; set; }
    public int? ClubDelegateNumber { get; set; }
    public string? Logotype { get; set; }
    public string? Language { get; set; }
}