using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using CategoryTable = Polyathlon.Models.Entities.CategoryTable;

namespace Polyathlon.ViewModels;

public partial class CategoryTableCollectionViewModel
    : CollectionViewModel<CategoryTableViewEntity, CategoryTable>, ISupportParameter
{
    public static CategoryTableCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new CategoryTableCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static CategoryTableViewEntity CreateViewEntity(CategoryTable entity, Flurl.Url origin)
    {
        CategoryTableViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected CategoryTableCollectionViewModel() : base(CreateViewEntity)
    {
    }
}