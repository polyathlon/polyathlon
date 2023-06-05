using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Exercise : EntityBase
{
    public string? AgeGroup { get; set; }
    public string? DiscplineName { get; set; }
}