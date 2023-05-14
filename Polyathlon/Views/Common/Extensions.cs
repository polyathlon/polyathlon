using System.Linq.Expressions;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraLayout;
using DevExpress.Utils;
using DevExpress.Utils.Design;

using Polyathlon.ViewModels.Common;
using Polyathlon.Models.Common;

namespace Polyathlon.Views
{
    internal static class ToolbarExtension
    {
        public static void BindCommandAndImage<TViewModel>(this DevExpress.Utils.MVVM.MVVMContextFluentAPI<TViewModel> fluentAPI, DevExpress.XtraEditors.ButtonPanel.IBaseButton button, Expression<Action<TViewModel>> commandSelector, string imageName = null)
            where TViewModel : class
        {
            fluentAPI.BindCommand((DevExpress.Utils.MVVM.ISupportCommandBinding)button, commandSelector);
            button.Properties.ImageUri = GetImageUri(imageName ?? ((MethodCallExpression)commandSelector.Body).Method.Name);
        }

        public static void BindCommandAndImage<TViewModel, T>(this DevExpress.Utils.MVVM.MVVMContextFluentAPI<TViewModel> fluentAPI, DevExpress.XtraEditors.ButtonPanel.IBaseButton button, Expression<Action<TViewModel, T>> commandSelector, Expression<Func<TViewModel, T>> commandParameterSelector = null, string imageName = null)
            where TViewModel : class
        {
            fluentAPI.BindCommand((DevExpress.Utils.MVVM.ISupportCommandBinding)button, commandSelector, commandParameterSelector);
            button.Properties.ImageUri = GetImageUri(imageName ?? ((MethodCallExpression)commandSelector.Body).Method.Name);
        }

        internal static DxImageUri GetImageUri(string imageName)
        {
            return CommonExtension.GetImageUri("Toolbar", imageName);
        }

        public static void SetupSearchControl(this SearchControl search, WindowsUIButtonPanel panel)
        {
            search.Width = 260;
            search.Height = 42;
            search.Left = panel.Width - search.Width - 20;
            search.Top = panel.Height / 2 - search.Height / 2;
            search.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            search.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            search.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            search.Properties.LookAndFeel.SetSkinStyle("Metropolis Dark");
        }
    }

    internal static class MenuExtensions
    {
        internal static DxImageUri GetImageUri(string imageName)
        {
            return CommonExtension.GetImageUri("Menu", imageName);
        }
    }

    internal static class CommonExtension
    {
        private static Dictionary<string, DxImageUri> cache = new Dictionary<string, DxImageUri>();

        internal static Image GetImage(string resourceType, string imageName)
        {
            string path = String.Format("DevExpress.DevAV.Resources.{0}.{1}.png", resourceType, imageName);
            return ResourceImageHelper.CreateImageFromResources(path, typeof(MainForm).Assembly);
        }

        internal static Image GetImageByUri(string resourceType, string imageName)
        {
            return GetImageByUri(resourceType, imageName, null);
        }

        internal static Image GetImageByUri(string resourceType, string imageName, ISvgPaletteProvider palette)
        {
            var uri = GetImageUri(resourceType, imageName);
            if (uri.HasSvgImage) return uri.GetSvgImage(Size.Empty, palette);
            if (uri.HasDefaultImage) return uri.GetDefaultImage();
            return null;
        }

        internal static DxImageUri GetImageUri(string resourceType, string imageName)
        {
            string uriString = ImageUriDictionary.GetUriByFile(resourceType + @"\" + imageName);
            return GetImageUriFromCache(uriString);
        }

        private static DxImageUri GetImageUriFromCache(string uri)
        {
            DxImageUri result;
            if (!cache.TryGetValue(uri, out result))
            {
                result = new DxImageUri();
                result.Uri = uri;
                cache.Add(uri, result);
            }
            return result;
        }
    }

    internal static class GridExtension
    {
        internal static void SetupTileView(this TileView view)
        {
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

        internal static void SetupCollectionGrid(this GridView view)
        {
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

        internal static void BindCollectionGrid<TViewModel, TEntityView, TEntity>(this DevExpress.Utils.MVVM.MVVMContext context, GridView gridView, BindingSource bindingSource)
            where TViewModel : CollectionViewModel<TEntityView, TEntity>
            where TEntity : EntityBase
            where TEntityView : ViewEntityBase<TEntity>
        {
            var fluentAPI = context.OfType<TViewModel>();
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.Entities);
            fluentAPI.SetBinding(gridView, gv => gv.LoadingPanelVisible, x => x.IsLoading);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(
                    x => x.SelectedEntity, args => args.Row as TEntityView,
                    (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                .EventToCommand(
                    x => x.Edit(null), x => x.SelectedEntity,
                    args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));
        }

        internal static void BindCollectionGridMy<TViewModel, TEntity, TViewEntity>(this DevExpress.Utils.MVVM.MVVMContext context, GridView gridView, BindingSource bindingSource)
            where TViewModel : ViewModels.RegionCollectionViewModel
            where TEntity : class
            where TViewEntity : class
        {
            var fluentAPI = context.OfType<TViewModel>();
            fluentAPI.SetBinding(gridView, gv => gv.LoadingPanelVisible, x => x.IsLoading);
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.Entities);
            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                .EventToCommand(
                    x => x.Edit(null), x => x.SelectedEntity,
                    args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));
        }

        internal static void BindTileGrid<TViewModel, TViewEntity, TEntity>(this DevExpress.Utils.MVVM.MVVMContext context, TileView tileView, BindingSource bindingSource)
            where TViewModel : CollectionViewModel<TViewEntity, TEntity>
            where TEntity : EntityBase
            where TViewEntity : ViewEntityBase<TEntity>
        {
            var fluentAPI = context.OfType<TViewModel>();
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.Entities);
            fluentAPI.WithEvent<TileView, FocusedRowObjectChangedEventArgs>(tileView, "FocusedRowObjectChanged")
                .SetBinding(
                    x => x.SelectedEntity, args => args.Row as TViewEntity,
                    (tView, entity) => tView.FocusedRowHandle = tView.FindRow(entity));
            fluentAPI.WithEvent<TileViewItemClickEventArgs>(tileView, "ItemDoubleClick")
                .EventToCommand(x => x.Edit(null), x => x.SelectedEntity);
        }
    }

    internal static class LayoutControlExtension
    {
        internal static void SetupLayoutControl(this LayoutControl layout)
        {
            layout.AllowCustomization = false;
            layout.OptionsView.UseParentAutoScaleFactor = true;
        }
    }

    internal static class ImageUriDictionary
    {
        internal static string GetUriByFile(string file)
        {
            if (List.ContainsKey(file))
                return List[file];
            return List[@"Toolbar\Cancel"];
        }

        private static readonly Dictionary<string, string> List = new Dictionary<string, string>() {
            { @"Menu\Sportsmen", "hybriddemo_customers;Svg" },
            { @"Menu\Regions", "hybriddemo_dashboard;Svg" },
            { @"Menu\Judges", "hybriddemo_employees;Svg" },
            { @"Menu\Clubs", "hybriddemo_opportunities;Svg" },
            { @"Menu\Competitions", "hybriddemo_products;Svg" },
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
}