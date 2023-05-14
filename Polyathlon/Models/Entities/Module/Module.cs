using Newtonsoft.Json;

using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

public record class Module : EntityBase
{
    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? Group { get; set; }

    public string? ViewType { get; set; }

    public string? SortOrder { get; set; }

    public TileOptions Tile { get; set; } = new();

    public List<Request> Requests = new();

    public List<Dependency> Dependencies = new();

    public record class Request
    {
        public Flurl.Url? Url { get; set; }
    }

    public record class Dependency
    {
        public string? Module { get; set; }
    }

    public record class TileOptions
    {
        [JsonProperty("title")]
        public string? Title { get; private set; }

        [JsonProperty("color")]
        public Color Color { get; private set; }

        [JsonProperty("fontSize")]
        public int FontSize { get; private set; }
    }
}