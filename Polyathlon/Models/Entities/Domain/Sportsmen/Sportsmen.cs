using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class Sportsmen : EntityBase
{
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? BirthYear { get; set; }
    public string? SportsmenNumber { get; set; }
    public string? RegionDelegate { get; set; }
    public string? ClubDelegate { get; set; }
    public string? Place { get; set; }
    public string? Balls { get; set; }
    public string? BestResultSprint { get; set; }
    public string? BestResultSwimmer { get; set; }
    public string? IsActive { get; set; }
    public string? Category { get; set; }
    public string? AgeGroup { get; set; }
    public string? Club { get; set; }
    public string? SetCategory { get; set; }
}