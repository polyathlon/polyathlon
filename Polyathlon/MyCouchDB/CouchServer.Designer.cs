using System.ComponentModel;

namespace Polyathlon.MyCouchDB;

using Options;

partial class CouchServer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        uriBuilder.Host = "localhost";
        uriBuilder.Scheme = "https";        
        uriBuilder.Port = 5984;
    }

    #endregion

    private UriBuilder uriBuilder = new();

    [Category("Behavior"), Description("Протокол"), DefaultValue(SchemeType.https)]
    public SchemeType Scheme {
        get => uriBuilder.Scheme == "https" ? SchemeType.https : SchemeType.http;
        set => uriBuilder.Scheme = value == SchemeType.https ? "https" : "https";
    }

    [Category("Behavior"), Description("Имя хоста"), DefaultValue("localhost")]
    public string Host { 
        get => uriBuilder.Host;
        set => uriBuilder.Host = value; 
    }

    [Category("Behavior"), Description("Номер порта: 5984"), DefaultValue(5984)]
    public int Port {
        get => uriBuilder.Port; 
        set => uriBuilder.Port = value;
    }

    [Category("Authentication"), Description("Имя пользователя")]
    public string? UserName { 
        get => uriBuilder.UserName; 
        set => uriBuilder.UserName = value;
    }

    [Category("Authentication"), Description("Пароль пользователя")]
    public string? Password { 
        get => uriBuilder.Password; 
        set => uriBuilder.Password = value; 
    }

    [Browsable(false)]
    public Uri Uri {
        get => uriBuilder.Uri;
        set => uriBuilder = new(value);
    }

    [Category("Authentication"), Description("Вид аутентификации"), DefaultValue(Options.AuthenticationType.None)]
    public AuthenticationType AuthenticationType { get; set; } = Options.AuthenticationType.None;
}
