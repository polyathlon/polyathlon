using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using Category = Polyathlon.Models.Entities.Category;

namespace Polyathlon.ViewModels
{
    public partial class CategoryViewModel : SingleObjectViewModel<Category, CategoryViewEntity, long>
    {
        public static CategoryViewModel Create()
        {
            return ViewModelSource.Create(() => new CategoryViewModel());
        }

        protected static CategoryViewEntity CreateNewViewEntity(Category region, Flurl.Url request)
        {
            Category entity = region with { };
            CategoryViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected CategoryViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}