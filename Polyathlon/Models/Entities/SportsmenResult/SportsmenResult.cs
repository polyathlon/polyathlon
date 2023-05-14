using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class SportsmenResult : EntityBase
{
    public string? Sportsmen { get; set; }
    public string? DisciplineName { get; set; }
    public string? Result { get; set; }
    public int? Balls { get; set; }
    public int? Info { get; set; }
    public string? Road { get; set; }
    public int? Place { get; set; }
    public string? Note { get; set; }
    public string? BestResult { get; set; }
    public string? Comment { get; set; }
    public int? CurrentNumber { get; set; }
}