using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class CompetitionKindViewEntity : ViewEntityBase<CompetitionKind>
{
    [Display(Name = "Спортивная дисциплина")]
    public string? Name
    {
        get => entity.Name;
        set => entity.Name = value;
    }

    [Display(Name = "Сокращение спортивной дисциплины")]
    public string? ShortName
    {
        get => entity.ShortName;
        set => entity.ShortName = value;
    }

    public CompetitionKindViewEntity(CompetitionKind competitionKind, Flurl.Url request)
        : base(competitionKind, request)
    {
    }

    public override object Clone()
    {
        CompetitionKind entity = this.entity with { };
        CompetitionKindViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}