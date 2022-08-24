using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

public record class Region : EntityBase {        
    public string? Name { get; set; }
    public string? ShortName { get; set; }
}