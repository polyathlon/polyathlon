using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class CategoriesTable : EntityBase
{
    public string? BallsMale { get; set; }
    public string? BallsFemale { get; set; }
    public string? CompetitionKind { get; set; }
    public string? Category { get; set; }
}