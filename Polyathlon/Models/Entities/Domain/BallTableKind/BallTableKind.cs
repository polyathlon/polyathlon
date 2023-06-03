using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class BallTableKind : EntityBase
{
    public string? Gender { get; set; }
    public string? MinAge { get; set; }
    public string? MaxAge { get; set; }
    public string? ExerciseName { get; set; }
}