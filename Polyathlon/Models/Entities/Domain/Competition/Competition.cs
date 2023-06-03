using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Competition : EntityBase
{
    public string? Name { get; set; }
    public string? EventDate { get; set; }
    public string? EventPlace { get; set; }
    public string? Year { get; set; }
    public string? RegionDelegateNumber { get; set; }
    public string? ClubDelegateNumber { get; set; }
    public string? Language { get; set; }
    public string? CompetitionKind { get; set; }
}