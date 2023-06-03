using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class BallTableViewEntity : ViewEntityBase<BallTable>
{
    [Display(Name = "Вид таблицы очков")]
    public string? BallTableKind
    {
        get => entity.BallTableKind;
        set => entity.BallTableKind = value;
    }

    [Display(Name = "Очки")]
    public string? Balls
    {
        get => entity.Balls;
        set => entity.Balls = value;
    }

    [Display(Name = "Результат")]
    public string? Result
    {
        get => entity.Result;
        set => entity.Result = value;
    }

    public BallTableViewEntity(BallTable ballTable, Flurl.Url request)
        : base(ballTable, request)
    {
    }

    public override object Clone()
    {
        BallTable entity = this.entity with { };
        BallTableViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}