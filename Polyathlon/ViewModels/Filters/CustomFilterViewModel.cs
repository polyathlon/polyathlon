using System;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace Polyathlon.ViewModels {
    public class CustomFilterViewModel {
        public static CustomFilterViewModel Create(Type entityType) {
            return ViewModelSource.Create(() => new CustomFilterViewModel(entityType));
        }

        protected CustomFilterViewModel(Type entityType) {
            EntityType = entityType;
        }

        public virtual Type EntityType { get; protected set; }
        public virtual bool Save { get; set; }
        public virtual CriteriaOperator FilterCriteria { get; set; }
        public virtual string FilterName { get; set; }
    }
}
