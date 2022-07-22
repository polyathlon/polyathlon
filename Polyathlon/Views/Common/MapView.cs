using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using Polyathlon.ViewModels;

namespace Polyathlon.Views {
    public partial class MapView : XtraUserControl {
        public MapView() {
            InitializeComponent();
        }

        protected VectorItemsLayer HomeLayer {
            get { return (VectorItemsLayer)(mapControl.Layers[2]); }
        }
        protected VectorItemsLayer StoresLayer {
            get { return (VectorItemsLayer)(mapControl.Layers[1]); }
        }
        protected MapItemStorage HomeData {
            get { return (MapItemStorage)HomeLayer.Data; }
        }
        protected BubbleChartDataAdapter StoreData {
            get { return (BubbleChartDataAdapter)StoresLayer.Data; }
        }
        private void InitBinding() {
            var fluentAPI = mvvmContext.OfType<MapViewModel>();
            fluentAPI.SetBinding(StoreData, s => s.DataSource, x => x.MapItems);
            fluentAPI.SetBinding(mapControl, m => m.CenterPoint, x => x.StoreCenterPoint);
            fluentAPI.SetBinding(StoresLayer, s => s.SelectedItem, x => x.SelectedStoreMapItem);
            fluentAPI.SetTrigger(x => x.SelectedStoreMapItem, (x) => {
                if(x != null) {
                    HomeData.Items.Clear();
                    HomeData.Items.Add(MapTemplate(x));
                }
            });
            fluentAPI.WithEvent<MapControl, MapItemClickEventArgs>(mapControl, "MapItemClick")
                .SetBinding(x => x.SelectedStoreMapItem, (args) => {
                    MapBubble bubble = args.Item as MapBubble;
                    if(bubble != null)
                        return fluentAPI.ViewModel.MapItems.FindLast(s => s.Latitude == bubble.Location.GetY());
                    return null;
                }, null);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if(!mvvmContext.IsDesignMode) {
                mapControl.InitMap();
                InitBinding();
            }
        }
        public void SetViewModel(MapViewModel viewModel) {
            mvvmContext.SetViewModel(typeof(MapViewModel), viewModel);
        }

        public Func<MapItemModel, DevExpress.XtraMap.MapItem> MapTemplate { get; set; }
    }
}
