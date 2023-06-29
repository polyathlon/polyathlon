using System.Data;

using Polyathlon.ViewModels;
using Polyathlon.Views;
using Polyathlon.Models.Entities;

using DevExpress.Utils;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars.Navigation;

namespace Polyathlon
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            using Forms.SplashScreenForm splashScreenForm = new();
            splashScreenForm.ShowDialog();

            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
            {
                InitializeNavigation();
            }
        }

        private void InitializeNavigation()
        {
            mvvmContext.RegisterService(DocumentManagerService.Create(navigationFrame));
            mvvmContext.RegisterService("FilterDialogService", DialogService.CreateFlyoutDialogService(this));

            var fluentAPI = mvvmContext.OfType<PolyathlonViewModel>();
            fluentAPI.SetItemsSourceBinding(
                tileBar,
                tb => tb.Groups, x => x.ModuleGroups,
                (group, moduleGroup) => object.Equals(group.Tag, moduleGroup),
                moduleGroup => CreateGroup(fluentAPI, moduleGroup)
            );
        }

        private TileBarGroup CreateGroup(MVVMContextFluentAPI<PolyathlonViewModel> fluentAPI, IGrouping<string, ModuleViewEntity> moduleGroup)
        {
            TileBarGroup group = new() { Tag = moduleGroup };
            string[] GroupName = moduleGroup.Key.Split('.', 2);

            group.Text = GroupName.Length == 1 ? GroupName[0] : GroupName[1];
            foreach (var module in moduleGroup.OrderBy(m => m.SortOrder))
            {
                group.Items.Add(RegisterModuleItem(fluentAPI, module));
            }

            return group;
        }

        private TileBarItem RegisterModuleItem(MVVMContextFluentAPI<PolyathlonViewModel> fluentAPI, ModuleViewEntity module)
        {
            TileBarItem item = new()
            {
                Tag = module,
                AllowGlyphSkinning = DefaultBoolean.True,
                Text = module.Tile.Title
            };

            item.Elements[0].ImageUri = MenuExtensions.GetImageUri(module.Name ?? "Regions");
            item.AppearanceItem.Normal.BackColor = module.Tile.Color;
            item.ItemSize = TileBarItemSize.Wide;

            fluentAPI.BindCommand(item, x => x.Show(null), x => module);

            return item;
        }
    }
}