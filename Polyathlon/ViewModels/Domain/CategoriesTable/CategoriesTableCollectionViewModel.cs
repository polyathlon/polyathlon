using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;
using Polyathlon.ViewModels.Common;

using CategoriesTable = Polyathlon.Models.Entities.CategoriesTable;

namespace Polyathlon.ViewModels;

public partial class CategoriesTableCollectionViewModel
    : CollectionViewModel<CategoriesTableViewEntity, CategoriesTable>, ISupportParameter
{
    public static CategoriesTableCollectionViewModel Create()
    {
        return ViewModelSource.Create(() => new CategoriesTableCollectionViewModel());
    }

    public override bool IsLoading { get; protected set; } = false;

    protected static CategoriesTableViewEntity CreateViewEntity(CategoriesTable entity, Flurl.Url origin)
    {
        CategoriesTableViewEntity ViewEntity = new(entity, origin);
        return ViewEntity;
    }

    protected CategoriesTableCollectionViewModel() : base(CreateViewEntity)
    {
    }
}