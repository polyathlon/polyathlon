using Polyathlon.DataModel.Common;

namespace Polyathlon.DataModel.Entities;

public record class Region : EntityBase {        
    public string? Name { get; set; }
    public string? ShortName { get; set; }
}
