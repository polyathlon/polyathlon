using System.ComponentModel.DataAnnotations;

using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

namespace Polyathlon.DataModel.Common;

public class ViewEntityBase<TEntity>
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
}