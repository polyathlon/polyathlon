using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using Category = Polyathlon.Models.Entities.Category;

namespace Polyathlon.ViewModels;

public partial class CategoryCollectionViewModel
    : CollectionViewModel<CategoryViewEntity, Category>, ISupportParameter
{
    public static CategoryCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new CategoryCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static CategoryViewEntity CreateViewEntity(Category entity, Flurl.Url origin)
    {
        CategoryViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected CategoryCollectionViewModel() : base(CreateViewEntity)
    {
    }
}