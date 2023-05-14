using DevExpress.Mvvm;

namespace Polyathlon.ViewModels.Common
{
    public class PersistentLayoutHelper
    {
        public static string? PersistentLogicalLayout
        {
            get { return Properties.LayoutSettings.Default.LogicalLayout; }
            set { Properties.LayoutSettings.Default.LogicalLayout = value; }
        }

        private static Dictionary<string, string>? persistentViewsLayout;

        public static Dictionary<string, string> PersistentViewsLayout
        {
            get
            {
                if (persistentViewsLayout == null)
                {
                    persistentViewsLayout = LogicalLayoutSerializationHelper.Deserialize(Properties.LayoutSettings.Default.ViewsLayout);
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
            Properties.LayoutSettings.Default.ViewsLayout = LogicalLayoutSerializationHelper.Serialize(PersistentViewsLayout);
            Properties.LayoutSettings.Default.Save();
        }

        public static void ResetLayout()
        {
            PersistentViewsLayout.Clear();
            PersistentLogicalLayout = null;
            SaveLayout();
        }
    }
}