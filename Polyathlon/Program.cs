using System.Globalization;

namespace Polyathlon;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        bool exit;
        using IDisposable singleInstanceApplicationGuard = Helpers.DirectoryHelper.SingleInstanceApplicationGuard("Polyathlon2022", out exit);

        if (exit)
            return;

        float fontSize = 11f;

        Application.CurrentCulture = CultureInfo.GetCultureInfo("en-us");

        ApplicationConfiguration.Initialize();

        MainForm = new MainForm();

        if (IsTablet)
        {
            SetupAsTablet();
        }

        Application.Run(MainForm);
    }

    public static MainForm? MainForm
    {
        get;
        private set;
    }

    private static bool? isTablet = null;

    public static bool IsTablet
    {
        get
        {
            isTablet ??= Utils.DeviceDetectorHelper.IsTablet;
            return isTablet.Value;
        }
    }

    public static void SetupAsTablet()
    {
        MainForm.FormBorderStyle = FormBorderStyle.None;
        MainForm.WindowState = FormWindowState.Maximized;
        DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = true;
    }
}