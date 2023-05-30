using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Sportsmen : EntityBase
{
    public string? Competition { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public int? BirthYear { get; set; }
    public string? Category { get; set; }
    public string? Club { get; set; }
    public int? SportsmenNumber { get; set; }
    public int? RegionDelegate { get; set; }
    public int? ClubDelegate { get; set; }
    public string? AgeGroup { get; set; }
    public int? Place { get; set; }
    public int? Balls { get; set; }
    public string? SetCategory { get; set; }
    public string? BestResultSprint { get; set; }
    public string? BestResultSwimmer { get; set; }
    public int? IsActive { get; set; }
}