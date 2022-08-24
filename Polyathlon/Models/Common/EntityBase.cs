using Newtonsoft.Json;

namespace Polyathlon.Models.Common;

public record class EntityBase {
    [JsonProperty("_id")]
    public string? Id { get; set; }
    [JsonProperty("_rev")]
    public string? Rev { get; set; }
}