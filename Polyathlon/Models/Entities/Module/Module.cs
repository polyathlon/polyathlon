using Newtonsoft.Json;
using Polyathlon.DataModel.Common;

namespace Polyathlon.DataModel.Entities;

public record class Module : EntityBase {

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? Group { get; set; }

    public string? ViewType { get; set; }

    public string? SortOrder { get; set; }

    public List<Request> Requests = new();
    
    public TileOptions Tile { get; set; } = new();

    public record class Request {
        public string? Url { get; set; }
    }

    public record class TileOptions {

        [JsonProperty("title")]
        public string Title { get; private set; }
        
        [JsonProperty("color")]
        public Color Color { get; private set; }

        [JsonProperty("fontSize")]
        public int FontSize { get; private set; }
    }

    ///// <summary>
    ///// Color of tileBarItem.
    ///// </summary>
    //public string TileTitle { get; private set; }

    ///// <summary>
    ///// Color of tileBarItem.
    ///// </summary>
    //[JsonProperty("tileColor")]
    //public Color TileColor { get; private set; }

    ///// <summary>
    ///// Font Size of tileBarItem.
    ///// </summary>
    //[JsonProperty("tileFontSize")]
    //public int TileFontSize { get; private set; }
    //public List<Request> Requests = new List<Request>();

    //public ModuleModel(string rev) {
    //    Rev = rev;
    //}
}



//public record class Request {
//    public string? Url { get; set; }
//}
