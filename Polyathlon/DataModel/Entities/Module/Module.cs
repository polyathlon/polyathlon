using Newtonsoft.Json;
using Polyathlon.DataModel.Common;

namespace Polyathlon.DataModel.Entities;

public record class Module : EntityBase {
    public class Request {
        public string? Url { get; set; }
    }
    public string? Title { get; set; }
    public string? Group { get; set; }
    public string? ViewDocumentType { get; set; }

    /// <summary>
    /// Color of tileBarItem.
    /// </summary>
    public string TileTitle { get; private set; }
  
    /// <summary>
    /// Color of tileBarItem.
    /// </summary>
    [JsonProperty("tileColor")]
    public Color TileColor { get; private set; }

    /// <summary>
    /// Font Size of tileBarItem.
    /// </summary>
    [JsonProperty("tileFontSize")]
    public int TileFontSize { get; private set; }
    public List<Request> Requests = new List<Request>();

    //public ModuleModel(string rev) {
    //    Rev = rev;
    //}
}
