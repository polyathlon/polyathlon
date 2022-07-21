using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Polyathlon.ViewModels;

namespace Polyathlon.Views {
    public partial class BaseFilterView : XtraUserControl {
        public BaseFilterView() {
            InitializeComponent();
            ((ITileControl)filterTileControl).Properties.LargeItemWidth = 200;
        }

        protected ITileItem CreateTileForFilter(FilterViewModelBase.FilterItem filter) {
            TileItem tile = new TileItem();
            tile.ItemSize = TileItemSize.Wide;
            tile.Tag = filter;
            TileItemElement element1 = new TileItemElement();
            element1.Appearance.Normal.FontSizeDelta = 128;
            element1.Appearance.Normal.ForeColor = Color.FromArgb(171, 171, 171);
            element1.Appearance.Normal.Options.UseFont = true;
            element1.Appearance.Normal.Options.UseForeColor = true;
            element1.Appearance.Selected.FontSizeDelta = 128;
            element1.Appearance.Selected.ForeColor = Color.FromArgb(151, 168, 209);
            element1.Appearance.Selected.Options.UseFont = true;
            element1.Appearance.Selected.Options.UseForeColor = true;
            element1.Appearance.Pressed.FontSizeDelta = 128;
            element1.Appearance.Pressed.ForeColor = Color.FromArgb(151, 168, 209);
            element1.Appearance.Pressed.Options.UseFont = true;
            element1.Appearance.Pressed.Options.UseForeColor = true;
            element1.TextAlignment = TileItemContentAlignment.TopRight;
            element1.TextLocation = new Point(-2, -12);
            element1.Text = filter.Count.ToString();
            tile.Elements.Add(element1);
            TileItemElement element2 = new TileItemElement();
            element2.ImageAlignment = TileItemContentAlignment.TopLeft;
            string[] location = filter.ImageUri.Split('/');
            string fileName = location[location.Length - 1];
            string imageName = fileName.Substring(0, fileName.IndexOf('.'));
            element2.ImageUri = CommonExtension.GetImageUri(location[location.Length - 2], imageName);
            element2.Text = filter.Name;
            element2.TextAlignment = TileItemContentAlignment.BottomLeft;
            tile.Elements.Add(element2);
            return tile;
        }

        protected void UpdateTileItem(ITileItem tileItem, FilterViewModelBase.FilterItem filter) {
            tileItem.Elements[0].Text = filter.Count.ToString();
        }

        public void SetViewModel(object viewModel) {
            mvvmContext.SetViewModel(mvvmContext.ViewModelType, viewModel);
            Init();
        }

        protected virtual void Init() {
        }
    }
}
