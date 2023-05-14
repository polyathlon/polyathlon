using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Union : EntityBase
{
    public string? Name { get; set; }
    public string? Competition { get; set; }
    public string? DisciplineKind { get; set; }
}