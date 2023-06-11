using DevExpress.Mvvm.POCO;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Entities;
using CategoriesTable = Polyathlon.Models.Entities.CategoriesTable;

namespace Polyathlon.ViewModels
{
    public partial class CategoriesTableViewModel : SingleObjectViewModel<CategoriesTable, CategoriesTableViewEntity, long>
    {
        public static CategoriesTableViewModel Create()
        {
            return ViewModelSource.Create(() => new CategoriesTableViewModel());
        }

        protected static CategoriesTableViewEntity CreateNewViewEntity(CategoriesTable region, Flurl.Url request)
        {
            CategoriesTable entity = region with { };
            CategoriesTableViewEntity regionViewEntity = new(entity, request);
            return regionViewEntity;
        }

        protected CategoriesTableViewModel() : base(CreateNewViewEntity)
        {
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
        }
    }
}