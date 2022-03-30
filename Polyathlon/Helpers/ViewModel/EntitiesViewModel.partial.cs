using System;
using System.Linq;
using System.Linq.Expressions;
using Polyathlon.DataModel;

namespace Polyathlon.ViewModel {
    partial class EntitiesViewModel<TEntity, TProjection, TUnitOfWork> {
        public virtual IQueryable<TEntity> GetEntities(Expression<Func<TEntity, bool>>? filter = null) {
            return getRepositoryFunc(CreateUnitOfWork()).GetFilteredEntities(filter);
        }
    }
}
