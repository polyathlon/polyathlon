using DevExpress.Utils.MVVM.UI;
using Polyathlon.ViewModels;
using Polyathlon.Models.Entities;
using Region = Polyathlon.Models.Entities.Region;

using DevExpress.Mvvm;

namespace Polyathlon.Views
{
    [ViewType("RegionCollectionView")]
    public partial class RegionCollectionView : BaseViewWithWinUIButtons, ISupportParameter
    {
        public object Parameter { get; set; }

        public RegionCollectionView()
        {
            InitializeComponent();
            gridView.SetupCollectionGrid();
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }

        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<RegionCollectionViewModel>();
            mvvmContext.BindCollectionGrid<RegionCollectionViewModel, RegionViewEntity, Region>(gridView, regionBindingSource);

            fluentAPI.SetObjectDataSourceBinding(regionBindingSource, x => x.Entities);
            fluentAPI.SetBinding(regionBindingSource, rbs => rbs.DataSource, x => x.Entities);
            fluentAPI.SetBinding(titleLabelItem1, t => t.Text, x => x.ModuleDescription.Tile.Title);

            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.New());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, entity) => x.Edit(entity), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], (x, entity) => x.Delete(entity), x => x.SelectedEntity);
        }
    }
}