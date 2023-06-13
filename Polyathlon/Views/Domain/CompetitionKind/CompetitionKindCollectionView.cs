using DevExpress.Utils.MVVM.UI;
using DevExpress.Mvvm;

using Polyathlon.ViewModels;
using Polyathlon.Models.Entities;

namespace Polyathlon.Views
{
    [ViewType("CompetitionKindCollectionView")]
    public partial class CompetitionKindCollectionView : BaseViewWithWinUIButtons, ISupportParameter
    {
        public object Parameter { get; set; }

        public CompetitionKindCollectionView()
        {
            InitializeComponent();
            gridView.SetupCollectionGrid();
            searchControl.SetupSearchControl(windowsUIButtonPanel);
            if (!mvvmContext.IsDesignMode)
                InitBindings();
        }

        private void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<CompetitionKindCollectionViewModel>();
            mvvmContext.BindCollectionGrid<CompetitionKindCollectionViewModel, CompetitionKindViewEntity, CompetitionKind>(gridView, competitionKindBindingSource);

            fluentAPI.SetObjectDataSourceBinding(competitionKindBindingSource, x => x.Entities);
            fluentAPI.SetBinding(competitionKindBindingSource, rbs => rbs.DataSource, x => x.Entities);
            fluentAPI.SetBinding(titleLabelItem1, t => t.Text, x => x.ModuleDescription.Tile.Title);

            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[0], x => x.New());
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[1], (x, entity) => x.Edit(entity), x => x.SelectedEntity);
            fluentAPI.BindCommandAndImage(windowsUIButtonPanel.Buttons[3], (x, entity) => x.Delete(entity), x => x.SelectedEntity);
        }
    }
}