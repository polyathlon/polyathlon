﻿using System.ComponentModel.DataAnnotations;

using Polyathlon.Models.Common;
using Polyathlon.Db.ModuleDb;

namespace Polyathlon.Models.Entities;

public class DisciplineKindViewEntity : ViewEntityBase<DisciplineKind>
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

    public DisciplineKindViewEntity(DisciplineKind disciplineKind, Flurl.Url request)
        : base(disciplineKind, request)
    {
    }

    public override object Clone()
    {
        DisciplineKind entity = this.entity with { };
        DisciplineKindViewEntity viewEntity = new(entity, Request);

        return viewEntity;
    }
}