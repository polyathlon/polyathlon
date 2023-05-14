using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class UnionFinishka : EntityBase
{
    public string? Union { get; set; }
    public string? FinishTime { get; set; }
    public int? SportsmenNumber { get; set; }
}