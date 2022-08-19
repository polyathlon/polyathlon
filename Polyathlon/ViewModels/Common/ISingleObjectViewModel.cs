namespace Polyathlon.ViewModels.Common;

/// <summary>
/// The base interface for view models representing a single entity.
/// </summary>
/// <typeparam name="TViewEntity">An entity type.</typeparam>
/// <typeparam name="IsNew">Is entity newly created or not.</typeparam>
public interface ISingleObjectViewModel<TViewEntity>                   
{
    /// <summary>
    /// The entity represented by a view model.
    /// </summary>
    TViewEntity Entity { get; }
    TViewEntity OldEntity { get; }


    /// <summary>
    /// Is entity newly created.
    /// </summary>
    bool IsNew();
}

///// <summary>
///// The base interface for view models representing a single entity.
///// </summary>
///// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
//public interface ISingleObjectViewModel<TEntity, TViewEntity, TPrimaryKey> : ISingleObjectViewModel<TViewEntity> 
//{
//    /// <summary>
//    /// The entity primary key value.
//    /// </summary>
//    TPrimaryKey PrimaryKey { get; }
//}
