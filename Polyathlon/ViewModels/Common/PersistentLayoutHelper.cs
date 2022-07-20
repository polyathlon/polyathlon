
using Polyathlon.Settings;
using DevExpress.Mvvm;

namespace Polyathlon.ViewModels.Common
{
    public class PersistentLayoutHelper
    {
        public static string? PersistentLogicalLayout
        {
            get { return Settings.LayoutSettings.Default.LogicalLayout; }
            set { Settings.LayoutSettings.Default.LogicalLayout = value; }
        }

        static Dictionary<string, string>? persistentViewsLayout;
        public static Dictionary<string, string> PersistentViewsLayout
        {
            get
            {
                if (persistentViewsLayout == null)
                {
                    persistentViewsLayout = LogicalLayoutSerializationHelper.Deserialize(Settings.LayoutSettings.Default.ViewsLayout);
                }
                return persistentViewsLayout;
            }
        }

        public static void TryDeserializeLayout(ILayoutSerializationService service, string viewName)
        {
            string? state = null;
            if (service != null && PersistentViewsLayout.TryGetValue(viewName, out state))
            {
                service.Deserialize(state);
            }
        }

        public static void TrySerializeLayout(ILayoutSerializationService service, string viewName)
        {
            if (service != null)
            {
                PersistentViewsLayout[viewName] = service.Serialize();
            }
        }

        public static void SaveLayout()
        {
            Settings.LayoutSettings.Default.ViewsLayout = LogicalLayoutSerializationHelper.Serialize(PersistentViewsLayout);
            Settings.LayoutSettings.Default.Save();
        }

        public static void ResetLayout()
        {
            PersistentViewsLayout.Clear();
            PersistentLogicalLayout = null;
            SaveLayout();
        }
    }
}
