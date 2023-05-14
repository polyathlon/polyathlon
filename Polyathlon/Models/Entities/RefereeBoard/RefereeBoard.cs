using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class RefereeBoard : EntityBase
{
    public string? Competition { get; set; }
    public string? RefereePosition { get; set; }
    public string? Referee { get; set; }
    public string? RefereeCategory { get; set; }
    public string? RefereeCity { get; set; }
}