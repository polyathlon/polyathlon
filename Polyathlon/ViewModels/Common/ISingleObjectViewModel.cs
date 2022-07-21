using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

namespace Polyathlon.ViewModels.Common
{
    /// <summary>
    /// The base interface for view models representing a single entity.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="IsNew">Is entity newly created or not.</typeparam>
    public interface ISingleObjectViewModel<TEntity> 
    {
        /// <summary>
        /// The entity represented by a view model.
        /// </summary>
        TEntity Entity { get; }

        /// <summary>
        /// Is entity newly created.
        /// </summary>
        bool IsNew();
    }

    /// <summary>
    /// The base interface for view models representing a single entity.
    /// </summary>
    /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
    public interface ISingleObjectViewModel<TEntity, TPrimaryKey> : ISingleObjectViewModel<TEntity> 
    {
        /// <summary>
        /// The entity primary key value.
        /// </summary>
        TPrimaryKey PrimaryKey { get; }
    }
}
