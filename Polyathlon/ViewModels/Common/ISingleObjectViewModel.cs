namespace Polyathlon.ViewModels.Common;

/// <summary>
/// The base interface for view models representing a single entity.
/// </summary>
/// <typeparam name="TViewEntity">An entity type.</typeparam>
public interface ISingleObjectViewModel<TViewEntity>
{
    /// <summary>
    /// The entity represented by a view model.
    /// </summary>
    TViewEntity ViewEntity { get; }

    TViewEntity OldViewEntity { get; }

    /// <summary>
    /// Is entity newly created.
    /// </summary>
    bool IsNew();
}