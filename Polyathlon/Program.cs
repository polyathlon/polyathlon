using System.Globalization;

namespace Polyathlon;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        Application.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
        
        
        ApplicationConfiguration.Initialize();        

        MainForm = new MainForm();

        Application.Run(MainForm);
    }

    public static MainForm? MainForm
    {
        get;
        private set;
    }

    static bool? isTablet = null;
    public static bool IsTablet
    {
        get
        {
            if (isTablet == null)
            {

                isTablet = Utils.DeviceDetectorHelper.IsTablet;
            }
            return isTablet.Value;
        }
    }

    public static void SetupAsTablet()
    {
        //MainForm.ShowTileNavPane();
        MainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        MainForm.WindowState = FormWindowState.Maximized;
        //DevExpress.XtraEditors.WindowsFormsSettings.PopupMenuStyle = XtraEditors.Controls.PopupMenuStyle.RadialMenu;
        DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = true;
    }
}
