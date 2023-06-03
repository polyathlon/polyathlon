using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class BallTable : EntityBase
{
    public string? Result { get; set; }
    public string? Balls { get; set; }
    public string? BallTableKind { get; set; }
}