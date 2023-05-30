using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class AgeCoefficient : EntityBase
{
    public int? Age { get; set; }
    public double? Coefficient { get; set; }
    public string? Competition { get; set; }
}