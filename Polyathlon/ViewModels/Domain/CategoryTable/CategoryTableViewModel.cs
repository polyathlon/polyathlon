using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using CategoryTable = Polyathlon.Models.Entities.CategoryTable;

namespace Polyathlon.ViewModels
{
    public partial class CategoryTableViewModel : SingleObjectViewModel<CategoryTable, CategoryTableViewEntity, long>
    {
        public static CategoryTableViewModel Create()
        {
            return ViewModelSource.Create(() => new CategoryTableViewModel());
        }

        protected static CategoryTableViewEntity CreateNewViewEntity(CategoryTable region, Flurl.Url request)
        {
            CategoryTable entity = region with { };
            CategoryTableViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected CategoryTableViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}