using System.ComponentModel.DataAnnotations;
using Polyathlon.DataModel.Common;

namespace Polyathlon.DataModel.Entities;

public record class ModuleViewEntity : ViewEntityBase<Module> {                

    [Display(Name = "Наименование")]
    public string? Name 
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Сокращение")]
    public string? ShortName
    {
        get => entity.ShortName;
        set => entity.ShortName = value;
    }

    public ModuleViewEntity(Module entity, string origin) : base(entity, origin) {
        
    }
}
