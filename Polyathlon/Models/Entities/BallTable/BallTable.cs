using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class BallTable : EntityBase
{
    public string? BallTableKind { get; set; }
    public int? Balls { get; set; }
    public double? Result { get; set; }
}