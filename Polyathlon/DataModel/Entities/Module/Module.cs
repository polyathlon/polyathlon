using Newtonsoft.Json;
using Polyathlon.DataModel.Common;

namespace Polyathlon.DataModel.Entities;

public record class Module : EntityBase {
    public class Request {
        public string? Url { get; set; }
    }
    public class Tile {
        /// <summary>
        /// Color of tileBarItem.
        /// </summary>
        [JsonProperty("tileColor")]
        public string Title { get; private set; }

        /// <summary>
        /// Color of tileBarItem.
        /// </summary>
        [JsonProperty("tileColor")]
        public Color Color { get; private set; }

        /// <summary>
        /// Font Size of tileBarItem.
        /// </summary>
        [JsonProperty("tileFontSize")]
        public int TileFontSize { get; private set; }
    }


    public string? Title { get; set; }
    public string? Group { get; set; }
    public string? DocumentType { get; set; }
        
    public List<Request> Requests = new List<Request>();
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
