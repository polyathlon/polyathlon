using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
//using DevExpress.DevAV.Common.ViewModel;
//using DevExpress.DevAV.DevAVDbDataModel1;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
//using DevExpress.DevAV.ViewModels;
using DevExpress.XtraMap;
using System.Reflection;
using System.Linq;
//using DevExpress.Snap;
using DevExpress.XtraCharts;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraLayout;
using System.Collections.Generic;

using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.Utils.Svg;
using DevExpress.Skins;
using DevExpress.XtraGrid.Columns;

namespace Polyathlon.Helpers.Views {
    internal static class ToolbarExtension {
        public static void BindCommandAndImage<TViewModel>(this DevExpress.Utils.MVVM.MVVMContextFluentAPI<TViewModel> fluentAPI, DevExpress.XtraEditors.ButtonPanel.IBaseButton button, Expression<Action<TViewModel>> commandSelector, string imageName = null)
            where TViewModel : class {
            fluentAPI.BindCommand((DevExpress.Utils.MVVM.ISupportCommandBinding)button, commandSelector);
            button.Properties.ImageUri = GetImageUri(imageName ?? ((MethodCallExpression)commandSelector.Body).Method.Name);
        }
        public static void BindCommandAndImage<TViewModel, T>(this DevExpress.Utils.MVVM.MVVMContextFluentAPI<TViewModel> fluentAPI, DevExpress.XtraEditors.ButtonPanel.IBaseButton button, Expression<Action<TViewModel, T>> commandSelector, Expression<Func<TViewModel, T>> commandParameterSelector = null, string imageName = null)
            where TViewModel : class {
            fluentAPI.BindCommand((DevExpress.Utils.MVVM.ISupportCommandBinding)button, commandSelector, commandParameterSelector);
            button.Properties.ImageUri = GetImageUri(imageName ?? ((MethodCallExpression)commandSelector.Body).Method.Name);
        }
        internal static DxImageUri GetImageUri(string imageName) {
            return CommonExtension.GetImageUri("Toolbar", imageName);
        }
        //public static TileControl CreateReportsGallery<TViewModel>(this DevExpress.Utils.MVVM.MVVMContextFluentAPI<TViewModel> fluentAPI, Expression<Action<TViewModel, EmployeeReportType>> commandSelector)
        //    where TViewModel : class {
        //    TileControl tc = new TileControl();
        //    tc.AllowDrag = false;
        //    tc.LayoutMode = TileControlLayoutMode.Adaptive;
        //    tc.Orientation = Orientation.Vertical;
        //    tc.OptionsAdaptiveLayout.ItemMinSize = new Size(300, 50);
        //    tc.Padding = new Padding(0);
        //    tc.ItemPadding = new Padding(15);
        //    tc.IndentBetweenItems = 0;
        //    tc.AppearanceItem.Normal.BackColor = Color.White;
        //    tc.AppearanceItem.Normal.ForeColor = Color.Black;
        //    tc.AppearanceItem.Normal.BorderColor = Color.LightGray;

        //    var group = new TileGroup();
        //    tc.Groups.Add(group);
        //    tc.BeginUpdate();
        //    CreateItem<TViewModel>(fluentAPI, commandSelector, group, EmployeeReportType.Profile);
        //    CreateItem<TViewModel>(fluentAPI, commandSelector, group, EmployeeReportType.Directory);
        //    CreateItem<TViewModel>(fluentAPI, commandSelector, group, EmployeeReportType.TaskList);
        //    tc.EndUpdate();
        //    return tc;
        //}
        //private static void CreateItem<TViewModel>(DevExpress.Utils.MVVM.MVVMContextFluentAPI<TViewModel> fluentAPI, Expression<Action<TViewModel, EmployeeReportType>> commandSelector, TileGroup group, EmployeeReportType value)
        //    where TViewModel : class {
        //    TileItem item = new TileItem();
        //    item.Text = EnumDisplayTextHelper.GetDisplayText(value);
        //    item.Image = CommonExtension.GetImage("PrintItems", "Print");
        //    item.ImageToTextAlignment = TileControlImageToTextAlignment.Left;
        //    item.ImageAlignment = TileItemContentAlignment.MiddleLeft;
        //    item.ImageToTextIndent = 15;
        //    fluentAPI.BindCommand(item, commandSelector, x => value);
        //    group.Items.Add(item);
        //}
        //public static void SetupSearchControl(this SearchControl search, WindowsUIButtonPanel panel) {
        //    search.Width = 260;
        //    search.Height = 42;
        //    search.Left = panel.Width - search.Width - 20;
        //    search.Top = panel.Height / 2 - search.Height / 2;
        //    search.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        //    search.BorderStyle = XtraEditors.Controls.BorderStyles.NoBorder;
        //    search.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
        //    search.Properties.LookAndFeel.SetSkinStyle("Metropolis Dark");
        //}
    }

    internal static class MenuExtensions {
        internal static DxImageUri GetImageUri(string imageName) {
            return CommonExtension.GetImageUri("Menu", imageName);
        }
    }

    internal static class WindowExtensions {
        internal static Image GetImage(string imageName) {
            return CommonExtension.GetImage("Window", imageName + ".Glyph");
        }
    }
    internal static class StatusIconsExtension {
        public static Image GetImage(string name) {
            return CommonExtension.GetImageByUri("Status", name);
        }
    }
    internal static class PriorityIconsExtension {
        static SvgPalette palette;
        static PriorityIconsExtension() {
            palette = new SvgPalette();
            palette.Colors.Add(new SvgColor("Black", Color.FromArgb(173, 3, 117)));
        }
        public static Image GetImage(string name) {
            return CommonExtension.GetImageByUri("Priority", name, palette);
        }
    }
    internal static class CommonExtension {
        static Dictionary<string, DxImageUri> cache = new Dictionary<string, DxImageUri>();
        internal static Image GetImage(string resourceType, string imageName) {
            string path = String.Format("DevExpress.DevAV.Resources.{0}.{1}.png", resourceType, imageName);
            return ResourceImageHelper.CreateImageFromResources(path, typeof(MainForm).Assembly);
        }
        internal static Image GetImageByUri(string resourceType, string imageName) {
            return GetImageByUri(resourceType, imageName, null);
        }
        internal static Image GetImageByUri(string resourceType, string imageName, ISvgPaletteProvider palette) {
            var uri = GetImageUri(resourceType, imageName);
            if(uri.HasSvgImage) return uri.GetSvgImage(Size.Empty, palette);
            if(uri.HasDefaultImage) return uri.GetDefaultImage();
            return null;
        }
        internal static DxImageUri GetImageUri(string resourceType, string imageName) {
            string uriString = ImageUriDictionary.GetUriByFile(resourceType + @"\" + imageName);
            return GetImageUriFromCache(uriString);
        }
        static DxImageUri GetImageUriFromCache(string uri) {
            DxImageUri result;
            if(!cache.TryGetValue(uri, out result)) {
                result = new DxImageUri();
                result.Uri = uri;
                cache.Add(uri, result);
            }
            return result;
        }
    }

    internal static class GridExtension {
        internal static void SetupTileView(this TileView view) {
            view.Appearance.ItemNormal.BorderColor = Color.Transparent;
            view.Appearance.ItemNormal.FontSizeDelta = -1;
            view.FocusBorderColor = Color.Transparent;
            view.OptionsTiles.AllowPressAnimation = false;
            view.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            view.OptionsTiles.IndentBetweenItems = 14;
            view.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(0);
            view.OptionsTiles.ItemSize = new Size(122, 175);
            view.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            view.OptionsTiles.ShowGroupText = false;
            view.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            view.OptionsTiles.ItemBorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Never;
        }
        internal static void SetupCollectionGrid(this GridView view) {
            view.BeginUpdate();
            view.FocusRectStyle = DrawFocusRectStyle.None;
            view.FooterPanelHeight = 60;
            view.OptionsBehavior.Editable = false;
            view.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            view.OptionsCustomization.AllowQuickHideColumns = false;
            view.OptionsCustomization.AllowColumnMoving = false;
            view.OptionsCustomization.AllowGroup = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsFind.AllowFindPanel = false;
            view.OptionsDetail.EnableMasterViewMode = false;
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            view.OptionsView.ShowFooter = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ShowIndicator = false;
            view.Appearance.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            view.Appearance.GroupPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            view.EndUpdate();
        }
        //internal static void BindCollectionGrid<TViewModel, TEntity, TProjection>(this DevExpress.Utils.MVVM.MVVMContext context, GridView gridView, BindingSource bindingSource)
        //    where TViewModel : CollectionViewModelBase<TEntity, TProjection, long, IDevAVDbUnitOfWork>
        //    where TEntity : class
        //    where TProjection : class {
        //    var fluentAPI = context.OfType<TViewModel>();
        //    fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.Entities);
        //    fluentAPI.SetBinding(gridView, gv => gv.LoadingPanelVisible, x => x.IsLoading);
        //    fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
        //        .SetBinding(
        //            x => x.SelectedEntity, args => args.Row as TProjection,
        //            (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
        //    fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
        //        .EventToCommand(
        //            x => x.Edit(null), x => x.SelectedEntity,
        //            args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));
        //}
        //internal static void BindTileGrid<TViewModel, TEntity>(this DevExpress.Utils.MVVM.MVVMContext context, TileView tileView, BindingSource bindingSource)
        //    where TViewModel : CollectionViewModel<TEntity, long, IDevAVDbUnitOfWork>
        //    where TEntity : class {
        //    BindTileGrid<TViewModel, TEntity, TEntity>(context, tileView, bindingSource);
        //}
        //internal static void BindTileGrid<TViewModel, TEntity, TProjection>(this DevExpress.Utils.MVVM.MVVMContext context, TileView tileView, BindingSource bindingSource)
        //    where TViewModel : CollectionViewModelBase<TEntity, TProjection, long, IDevAVDbUnitOfWork>
        //    where TEntity : class
        //    where TProjection : class {
        //    var fluentAPI = context.OfType<TViewModel>();
        //    fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.Entities);
        //    fluentAPI.WithEvent<TileView, FocusedRowObjectChangedEventArgs>(tileView, "FocusedRowObjectChanged")
        //        .SetBinding(
        //            x => x.SelectedEntity, args => args.Row as TProjection,
        //            (tView, entity) => tView.FocusedRowHandle = tView.FindRow(entity));
        //    fluentAPI.WithEvent<TileViewItemClickEventArgs>(tileView, "ItemDoubleClick")
        //        .EventToCommand(x => x.Edit(null), x => x.SelectedEntity);
        //}
        //internal static void BindCollectionGrid<TViewModel, TEntity>(this DevExpress.Utils.MVVM.MVVMContext context, GridView view, BindingSource bindingSource)
        //    where TViewModel : CollectionViewModel<TEntity, long, IDevAVDbUnitOfWork>
        //    where TEntity : class {
        //    BindCollectionGrid<TViewModel, TEntity, TEntity>(context, view, bindingSource);
        //}
    }
    //internal static class MapExtension {
    //    internal static void InitMap(this MapControl mapControl) {
    //        if (Assembly.GetEntryAssembly() == null)
    //            return;
    //        mapControl.SelectionMode = DevExpress.XtraMap.ElementSelectionMode.None;
    //        var mapStreamDbf = Assembly.GetEntryAssembly().GetManifestResourceStream("DevExpress.DevAV.Resources.Map.NorthAmerica.dbf");
    //        var mapStream = Assembly.GetEntryAssembly().GetManifestResourceStream("DevExpress.DevAV.Resources.Map.NorthAmerica.shp");
    //        VectorItemsLayer layer = mapControl.Layers.OfType<VectorItemsLayer>().Where(l => l.Data is ShapefileDataAdapter).FirstOrDefault();
    //        if (layer != null)
    //            (layer.Data as ShapefileDataAdapter).LoadFromStream(mapStream, mapStreamDbf);
    //    }
    //    internal static DevExpress.XtraMap.MapItem CreateHomeOfficeItemForCustomer(MapItemModel item) {
    //        MapCallout home = GetHomeOfficeItem(item);
    //        home.Text = string.Format("TOTAL SALES{3}<color=47,81,165><b><size=+4>{0:c}</color></size></b>{3}TOTAL OPPORTUNITIES{3}<color=206,113,0><b><size=+4>{1:c}</color></size></b>{3}{2}", item.TotalSales, item.TotalQuotes, item.City, "<br>");
    //        return home;
    //    }
    //    internal static DevExpress.XtraMap.MapItem CreateHomeOfficeItemForQuote(MapItemModel item) {
    //        MapCallout home = GetHomeOfficeItem(item);
    //        home.Text = string.Format("TOTAL OPPORTUNITIES{2}<color=206,113,0><b><size=+4>{0:c}</color></size></b>{2}{1}", item.TotalSales, item.City, "<br>");
    //        return home;
    //    }
    //    private static MapCallout GetHomeOfficeItem(MapItemModel item) {
    //        var mc = new MapCallout();
    //        mc.Location = new GeoPoint(item.Latitude, item.Longitude);
    //        mc.AllowHtmlText = true;
    //        mc.TextAlignment = TextAlignment.TopCenter;
    //        mc.Font = new Font("Segoe UI", 13);
    //        mc.TextColor = Color.FromArgb(145, 145, 145);            
    //        return mc;
    //    }
    //}
    //internal static class SnapExtension {
    //    internal static void LoadTemplate(this SnapControl snapControl) {
    //        var template = "Order.snx";
    //        using (var stream = MailMergeTemplatesHelper.GetTemplateStream(template)) {
    //            if (stream != null) {
    //                snapControl.LoadDocumentTemplate(stream, DevExpress.Snap.Core.API.SnapDocumentFormat.Snap);
    //            }
    //        }
    //    }
    //}
    internal static class ChartExtension {
        internal static void DrawSeries(this ChartControl chartControl, CustomDrawSeriesPointEventArgs e) {
            int imageSizeW = 18, imageSizeH = 14;
            var image = new Bitmap(imageSizeW, imageSizeH);
            using (var graphics = Graphics.FromImage(image)) {
                graphics.FillRectangle(new SolidBrush(e.LegendDrawOptions.Color), new Rectangle(new Point(0, 0), new Size(imageSizeW, imageSizeH)));
            }
            e.LegendMarkerImage = image;
            e.DisposeLegendMarkerImage = true;
            e.LegendMarkerVisible = true;
        }
    }
    internal static class LayoutControlExtension {
        internal static void SetupLayoutControl(this LayoutControl layout) {
            layout.AllowCustomization = false;
            layout.OptionsView.UseParentAutoScaleFactor = true;
        }
    }

    internal static class ImageUriDictionary {
        internal static string GetUriByFile(string file) {
            if(List.ContainsKey(file))
                return List[file];
            return List[@"Toolbar\Cancel"];
        }
        static readonly Dictionary<string, string> List = new Dictionary<string, string>() { 
            { @"Menu\Customers", "hybriddemo_customers;Svg" },
            { @"Menu\Dashboard", "hybriddemo_dashboard;Svg" },
            { @"Menu\Employees", "hybriddemo_employees;Svg" },
            { @"Menu\Opportunities", "hybriddemo_opportunities;Svg" },
            { @"Menu\Products", "hybriddemo_products;Svg" },
            { @"Menu\Sales", "hybriddemo_sales;Svg" },
            { @"Menu\Tasks", "hybriddemo_tasks;Svg" },

            { @"Toolbar\New", "hybriddemo_new;Svg" },
            { @"Toolbar\Edit", "hybriddemo_edit;Svg" },
            { @"Toolbar\SaveAndClose", "hybriddemo_save;Svg" },
            { @"Toolbar\Delete", "hybriddemo_delete;Svg" },
            { @"Toolbar\Print", "hybriddemo_print;Svg" },
            { @"Toolbar\Settings", "hybriddemo_print;Svg" },
            { @"Toolbar\Cancel", "hybriddemo_cancel;Svg" },
            { @"Toolbar\SortAZ", "hybriddemo_descending;Svg" },
            { @"Toolbar\SortZA", "hybriddemo_ascending;Svg" },
            { @"Toolbar\Task", "hybriddemo_task;Svg" },
            { @"Toolbar\Note", "hybriddemo_note;Svg" },
            { @"Toolbar\Meeting", "hybriddemo_meeting;Svg" },
            { @"Toolbar\MailMerge", "hybriddemo_mail%20merge;Svg" },
            { @"Toolbar\ZoomIn", "hybriddemo_zoom%20in;Svg" },
            { @"Toolbar\ZoomOut", "hybriddemo_zoom%20out;Svg" },
            { @"Toolbar\CustomFilter", "hybriddemo_custom%20filter;Svg" },
            { @"Toolbar\PivotTable", "hybriddemo_pivot%20table;Svg" },
            { @"Toolbar\MapView", "hybriddemo_map%20view;Svg" },
            { @"Toolbar\OrderList", "hybriddemo_order%20list;Svg" },
            { @"Toolbar\SalesMap", "hybriddemo_sales%20map;Svg" },

            { @"Employees\All", "hybriddemo_all%20employees;Svg" },
            { @"Employees\Commission", "hybriddemo_commission;Svg" },
            { @"Employees\OnLeave", "hybriddemo_on%20leave;Svg" },
            { @"Employees\Probation", "hybriddemo_contract;Svg" },
            { @"Employees\Salaried", "hybriddemo_salaried;Svg" },
            { @"Employees\Terminated", "hybriddemo_terminated;Svg" },

            { @"Products\All", "hybriddemo_all%20products;Svg" },
            { @"Products\Automation", "hybriddemo_automation;Svg" },
            { @"Products\Monitors", "hybriddemo_monitors;Svg" },
            { @"Products\Projectors", "hybriddemo_projectors;Svg" },
            { @"Products\TVs", "hybriddemo_tvs;Svg" },
            { @"Products\VideoPlayers", "hybriddemo_video%20players;Svg" },

            { @"Tasks\AllTasks", "hybriddemo_all%20tasks;Svg" },
            { @"Tasks\Completed", "hybriddemo_completed;Svg" },
            { @"Tasks\Deferred", "hybriddemo_deferred;Svg" },
            { @"Tasks\HighPriority", "hybriddemo_high%20priority;Svg" },
            { @"Tasks\InProgress", "hybriddemo_in%20progress;Svg" },
            { @"Tasks\NotStarted", "hybriddemo_not%20started;Svg" },
            { @"Tasks\Urgent", "hybriddemo_urgent;Svg" },

            { @"Status\Completed", "hybriddemo_scompleted;Svg" },
            { @"Status\Deferred", "hybriddemo_sdeferred;Svg" },
            { @"Status\InProgress", "hybriddemo_sinprogress;Svg" },
            { @"Status\NeedAssistance", "hybriddemo_need%20assistance;Svg" },
            { @"Status\NotStarted", "hybriddemo_snotstarted;Svg" },

            { @"Priority\HighPriority", "hybriddemo_priority%20urgent;Svg" },
            { @"Priority\LowPriority", "hybriddemo_priority%20low;Svg" },
            { @"Priority\MediumPriority", "hybriddemo_priority%20normal;Svg" },
            { @"Priority\NormalPriority", "hybriddemo_priority%20high;Svg" },
        };
    }

    public class LabelTabController {
        private object[] list;
        private object editValue;
        public event EventHandler EditValueChanged;
        public LabelTabController(object eValue, params object[] list) {
            this.list = list;
            EditValue = eValue;
            foreach(LabelControl lb in list) {
                lb.Click += (s, e) => EditValue = ((LabelControl)s).Tag;
            }
        }
        public object EditValue {
            get {
                return editValue;
            }
            set {
                editValue = value;
                if(EditValueChanged != null) {
                    EditValueChanged(EditValue, EventArgs.Empty);
                }
                foreach(LabelControl lc in list) {
                    if(EditValue.Equals(lc.Tag)) {
                        lc.Appearance.ForeColor = CommonColors.GetQuestionColor(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                    }
                    else {
                        lc.Appearance.ForeColor = Color.Empty;
                    }
                }
            }
        }
    }
}
