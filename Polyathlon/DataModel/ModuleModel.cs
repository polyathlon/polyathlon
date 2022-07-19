using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Polyathlon.DataModel
{
    public class ModuleModel
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }
        [JsonProperty("_rev")]
        public string? Rev { get; set; }
        public string? Title { get; set; }
        public string? Group { get; set; }
        public string? ViewDocumentType { get; set; }
        public Color? tileColor { get; set; }
    }
}
