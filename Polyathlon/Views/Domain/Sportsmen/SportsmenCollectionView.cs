using DevExpress.Utils.MVVM.UI;
using DevExpress.Mvvm;

using Polyathlon.ViewModels;
using Polyathlon.Models.Entities;

namespace Polyathlon.Views
{
    [ViewType("SportsmenCollectionView")]
    public partial class SportsmenCollectionView : BaseViewWithWinUIButtons, ISupportParameter
    {
        public object Parameter { get; set; }

        public SportsmenCollectionView()
        {
            InitializeComponent();
            gridView.SetupCollectionGrid();
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }

        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<SportsmenCollectionViewModel>();
            mvvmContext.BindCollectionGrid<SportsmenCollectionViewModel, SportsmenViewEntity, Sportsmen>(gridView, sportsmenBindingSource);

            fluentAPI.SetObjectDataSourceBinding(sportsmenBindingSource, x => x.Entities);
            fluentAPI.SetBinding(sportsmenBindingSource, rbs => rbs.DataSource, x => x.Entities);
            fluentAPI.SetBinding(titleLabelItem1, t => t.Text, x => x.ModuleDescription.Tile.Title);

            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.New());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, entity) => x.Edit(entity), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], (x, entity) => x.Delete(entity), x => x.SelectedEntity);
        }
    }
}