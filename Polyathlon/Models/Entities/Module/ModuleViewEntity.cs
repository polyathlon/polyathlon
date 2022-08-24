using System.ComponentModel.DataAnnotations;
using Polyathlon.Models.Common;

namespace Polyathlon.Models.Entities;

public class ModuleViewEntity : ViewEntityBase<Module> {

    [Display(Name = "Название")]
    public string? Name {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Отображение")]
    public string? Title {
        get => entity.Title;
        set => entity.Title = value;
    }

    [Display(Name = "Группа")]
    public string? Group {
        get => entity.Group;
        set => entity.Group = value;
    }

    [Display(Name = "Имя просмотра")]
    public string? ViewType {
        get => entity.ViewType;
        set => entity.ViewType = value;
    }

    [Display(Name = "Порядок сортировки")]
    public string? SortOrder {
        get => entity.SortOrder;
        set => entity.SortOrder = value;
    }

    [Display(Name = "Список запросов")]
    public List<Module.Request> Requests {
        get => entity.Requests;
        set => entity.Requests = value;
    }

    [Display(Name = "Параметры отображения")]

    public Module.TileOptions Tile {
        get => entity.Tile;
        set => entity.Tile = value;
    }
    
    public ModuleViewEntity(Module entity, Flurl.Url origin) : base(entity, origin) {
        
    }

    public override object Clone() {
        Module entity = this.entity with { };
        ModuleViewEntity viewEntity = new(entity, "1");
        return viewEntity;
    }
}
