using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class DisciplineNameViewEntity : ViewEntityBase<DisciplineName>
{
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

    [Display(Name = "Вид дисциплины")]
    public string? DisciplineKind
    {
        get => entity.DisciplineKind;
        set => entity.DisciplineKind = value;
    }

    public DisciplineNameViewEntity(DisciplineName disciplineName, Flurl.Url request)
        : base(disciplineName, request)
    {
    }

    public override object Clone()
    {
        DisciplineName entity = this.entity with { };
        DisciplineNameViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}