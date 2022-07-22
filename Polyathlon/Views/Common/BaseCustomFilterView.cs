using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using Polyathlon.ViewModels;

namespace Polyathlon.Views {
    public partial class BaseCustomFilterView : XtraUserControl {
        public BaseCustomFilterView() {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public void SetViewModel(FilterViewModelBase filterViewModel) {
            mvvmContext.SetViewModel(typeof(FilterViewModelBase), filterViewModel);
            InitBindings();
        }
        
        void InitBindings() {
            var fluent = mvvmContext.OfType<FilterViewModelBase>();
            fluent.SetBinding(tileBar,
                x => x.SelectedItem, x => x.SelectedItem,
                filter => (TileItem)tileBarGroup2.Items.FirstOrDefault(item => Equals(item.Tag, filter)), 
                item => (FilterViewModelBase.FilterItem)item.Tag);
            fluent.SetItemsSourceBinding(tileBarGroup2,
                tg => tg.Items, x => x.CustomFilters, 
                (item, filter) => object.Equals(item.Tag, filter),
                (filter) => CreateTileForFilter(filter));
        }
        ITileItem CreateTileForFilter(FilterViewModelBase.FilterItem filter) {
            var tile = new TileBarItem();
            tile.ItemSize = TileBarItemSize.Wide;
            tile.Tag = filter;
            TileItemElement element = new TileItemElement();
            element.TextAlignment = TileItemContentAlignment.MiddleCenter;
            element.Text = filter.Name;
            tile.Elements.Add(element);
            return tile;
        }
    }
}
