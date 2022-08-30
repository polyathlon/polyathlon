using Newtonsoft.Json;

namespace Polyathlon.Models.Common;

public record class EntityBase {
    [JsonProperty("_id")]
    public string? Id { get; set; }
    [JsonProperty("_rev", NullValueHandling = NullValueHandling.Ignore)]
    public string? Rev { get; set; }
}