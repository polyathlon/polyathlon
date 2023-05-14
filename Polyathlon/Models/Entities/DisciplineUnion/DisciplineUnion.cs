using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class DisciplineUnion : EntityBase
{
    public string? Union { get; set; }
    public string? Discipline { get; set; }
}