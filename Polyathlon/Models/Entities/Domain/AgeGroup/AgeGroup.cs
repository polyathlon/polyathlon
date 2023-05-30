using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class AgeGroup : EntityBase
{
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public int? SortOrder { get; set; }
    public string? Gender { get; set; }
    public string? Competition { get; set; }
}