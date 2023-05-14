using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record class ThrowResult : EntityBase
{
    public string? Sportsmen { get; set; }
    public string? Try1 { get; set; }
    public string? Try2 { get; set; }
    public string? Try3 { get; set; }
}