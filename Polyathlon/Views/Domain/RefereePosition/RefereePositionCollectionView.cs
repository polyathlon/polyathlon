using DevExpress.Utils.MVVM.UI;
using DevExpress.Mvvm;

using Polyathlon.ViewModels;
using Polyathlon.Models.Entities;

namespace Polyathlon.Views
{
    [ViewType("RefereePositionCollectionView")]
    public partial class RefereePositionCollectionView : BaseViewWithWinUIButtons, ISupportParameter
    {
        public object Parameter { get; set; }

        public RefereePositionCollectionView()
        {
            InitializeComponent();
            gridView.SetupCollectionGrid();
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }

        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<RefereePositionCollectionViewModel>();
            mvvmContext.BindCollectionGrid<RefereePositionCollectionViewModel, RefereePositionViewEntity, RefereePosition>(gridView, regionBindingSource);

            fluentAPI.SetObjectDataSourceBinding(regionBindingSource, x => x.Entities);
            fluentAPI.SetBinding(regionBindingSource, rbs => rbs.DataSource, x => x.Entities);
            fluentAPI.SetBinding(titleLabelItem1, t => t.Text, x => x.ModuleDescription.Tile.Title);

            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.New());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, entity) => x.Edit(entity), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], (x, entity) => x.Delete(entity), x => x.SelectedEntity);
        }
    }
}