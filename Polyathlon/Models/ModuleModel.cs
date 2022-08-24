using Newtonsoft.Json;
using Polyathlon.Models.Common;

namespace Polyathlon.DataModel; 

public record class ModuleModel : EntityBase {
    public class Request {
        public string? Url { get; set; }
    }
    public string? Title { get; set; }
    public string? Group { get; set; }
    public string? ViewDocumentType { get; set; }
    public Color TileColor { get; set; }

    public List<Request> Requests = new List<Request>();

    public ModuleModel(string rev) {
        Rev = rev;
    }
}