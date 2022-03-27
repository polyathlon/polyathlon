
using Polyathlon.Settings;
using DevExpress.Mvvm;

namespace Polyathlon.Helpers.ViewModel
{
    public class PersistentLayoutHelper
    {
        public static string? PersistentLogicalLayout
        {
            get { return Polyathlon.Settings.LayoutSettings.Default.LogicalLayout; }
            set { Polyathlon.Settings.LayoutSettings.Default.LogicalLayout = value; }
        }

        static Dictionary<string, string>? persistentViewsLayout;
        public static Dictionary<string, string> PersistentViewsLayout
        {
            get
            {
                if (persistentViewsLayout == null)
                {
                    persistentViewsLayout = LogicalLayoutSerializationHelper.Deserialize(Polyathlon.Settings.LayoutSettings.Default.ViewsLayout);
                }
                return persistentViewsLayout;
            }
        }

        public static void TryDeserializeLayout(ILayoutSerializationService service, string viewName)
        {
            string? state = null;
            if (service != null && PersistentLayoutHelper.PersistentViewsLayout.TryGetValue(viewName, out state))
            {
                service.Deserialize(state);
            }
        }

        public static void TrySerializeLayout(ILayoutSerializationService service, string viewName)
        {
            if (service != null)
            {
                PersistentLayoutHelper.PersistentViewsLayout[viewName] = service.Serialize();
            }
        }

        public static void SaveLayout()
        {
            Polyathlon.Settings.LayoutSettings.Default.ViewsLayout = LogicalLayoutSerializationHelper.Serialize(PersistentViewsLayout);
            Polyathlon.Settings.LayoutSettings.Default.Save();
        }

        public static void ResetLayout()
        {
            PersistentViewsLayout.Clear();
            PersistentLogicalLayout = null;
            SaveLayout();
        }
    }
}
