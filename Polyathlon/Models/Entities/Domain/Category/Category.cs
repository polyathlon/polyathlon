using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Category : EntityBase
{
    public string? Name { get; set; }
    public string? ShortNameRoman { get; set; }
    public string? ShortNameArabic { get; set; }
    public string? MinBallsMale { get; set; }
    public string? MinBallsFemale { get; set; }
}