using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class SportsmenRelayResult : EntityBase
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
    public int? StartBalls { get; set; }
    public int? SumBalls { get; set; }
    public int? SumPlace { get; set; }
    public string? SumResult { get; set; }
    public string? SkiResult { get; set; }
    public int? SkiBalls { get; set; }
    public int? SkiInfo { get; set; }
    public string? SkiRoad { get; set; }
    public int? SkiPlace { get; set; }
    public string? SkiNote { get; set; }
    public string? SkiBestResult { get; set; }
    public string? SkiComment { get; set; }
    public int? SkiCurrentNumber { get; set; }
    public int? SkiStartNumber { get; set; }
    public int? SkiSumBalls { get; set; }
    public int? SkiSumPlace { get; set; }
    public string? SkiSumResult { get; set; }
}