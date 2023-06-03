using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class RefereeBoardViewEntity : ViewEntityBase<RefereeBoard>
{
    [Display(Name = "Соревнование")]
    public string? Competition
    {
        get => entity.Competition;
        set => entity.Competition = value;
    }

    [Display(Name = "Должность")]
    public string? RefereePosition
    {
        get => entity.RefereePosition;
        set => entity.RefereePosition = value;
    }

    [Display(Name = "Судья")]
    public string? Referee
    {
        get => entity.Referee;
        set => entity.Referee = value;
    }

    [Display(Name = "Категория")]
    public string? RefereeCategory
    {
        get => entity.Referee;
        set => entity.Referee = value;
    }

    [Display(Name = "Город")]
    public string? RefereeCity
    {
        get => entity.Referee;
        set => entity.Referee = value;
    }

    public RefereeBoardViewEntity(RefereeBoard refereeBoard, Flurl.Url request)
        : base(refereeBoard, request)
    {
    }

    public override object Clone()
    {
        RefereeBoard entity = this.entity with { };
        RefereeBoardViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}