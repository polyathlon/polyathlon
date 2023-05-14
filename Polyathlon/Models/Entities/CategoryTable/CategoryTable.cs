using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class CategoryTable : EntityBase
{
    public string? CompetitionKind { get; set; }
    public string? Category { get; set; }
    public int? Balls { get; set; }
    public int? BallsW { get; set; }
}