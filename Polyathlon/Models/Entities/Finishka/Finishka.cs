using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Finishka : EntityBase
{
    public string? Competition { get; set; }
    public string? DisciplineName { get; set; }
    public string? Gender { get; set; }
    public string? FinishTime { get; set; }
    public int? SportsmenNumber { get; set; }
}