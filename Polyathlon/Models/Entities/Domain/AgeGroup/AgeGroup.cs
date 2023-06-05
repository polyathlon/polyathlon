using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class AgeGroup : EntityBase
{
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? MinAge { get; set; }
    public string? MaxAge { get; set; }
    public string? Gender { get; set; }
    public string? SortOrder { get; set; }
}