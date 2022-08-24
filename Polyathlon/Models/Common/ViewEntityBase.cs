﻿using System.ComponentModel.DataAnnotations;

namespace Polyathlon.Models.Common;

public abstract class ViewEntityBase<TEntity> : ICloneable
    where TEntity : EntityBase {

    [Display(Name = "Идентификатор", AutoGenerateField = false)]
    public string? Id {
        get => entity.Id;
        set { 
            entity.Id = value;            
        }
    }

    // [Display(Name = "Тест", AutoGenerateField = false)]
    //string test = "";
    //public string? Test {
    //    get => test;
    //    set {
    //        test = value;
    //        //((IPOCOViewModel)this).RaisePropertyChanged(test);
    //        //    this.RaisePropertyChanged(x => x.Id);
    //    }
    //}


    //{
    //        test = value;
    //        //((IPOCOViewModel)this).RaisePropertyChanged(test);
    //        //    this.RaisePropertyChanged(x => x.Id);
    //    }
    //}

    [Display(Name = "Ревизия", AutoGenerateField = false)]
    public string? Rev {
        get => entity.Rev;
        set => entity.Rev = value;
    }

    [Display(AutoGenerateField = false)]
    protected TEntity entity;

    [Display(AutoGenerateField = false)]
    public TEntity Entity {
        get => entity;
        set => entity = value;
    }

    [Display(AutoGenerateField = false)]
    public Flurl.Url Origin { get; set; }

    public ViewEntityBase(TEntity entity, string origin) {
        this.entity = entity;
        Origin = origin;
    }

    public abstract object Clone();
    //{
    //    TEntity entity = this.entity with { };
    //    ViewEntityBase<TEntity> viewEntity = new(entity, "1");
    //    return viewEntity;
    //}
}