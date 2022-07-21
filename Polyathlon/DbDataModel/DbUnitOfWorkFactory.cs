using System;
using System.Linq;
using System.Data;

using System.Linq.Expressions;
using System.Collections.Generic;

using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;
using Polyathon.DbDataModel;

namespace Polyathlon.DataModel
{
    class DbUnitOfWorkFactory<TUnitOfWork> : IUnitOfWorkFactory<TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        Func<TUnitOfWork> createUnitOfWork;

        public DbUnitOfWorkFactory(Func<TUnitOfWork> createUnitOfWork)
        {
            this.createUnitOfWork = createUnitOfWork;
        }

        TUnitOfWork IUnitOfWorkFactory<TUnitOfWork>.CreateUnitOfWork()
        {
            return createUnitOfWork();
        }

        IInstantFeedbackSource<TProjection> IUnitOfWorkFactory<TUnitOfWork>.CreateInstantFeedbackSource<TEntity, TProjection, TPrimaryKey>(
            Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc,
            Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection)
        {
            var threadSafeProperties = new TypeInfoProxied(TypeDescriptor.GetProperties(typeof(TProjection)), null).UIDescriptors;
            if (projection == null)
            {
                projection = x => x as IQueryable<TProjection>;
            }
            var source = new EntityInstantFeedbackSource((GetQueryableEventArgs e) => e.QueryableSource = projection(getRepositoryFunc(createUnitOfWork())))
            {
                KeyExpression = getRepositoryFunc(createUnitOfWork()).GetPrimaryKeyPropertyName(),
            };
            
            return new InstantFeedbackSource<TProjection>(source, threadSafeProperties);
        }
    }
}
