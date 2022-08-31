using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Polyathlon.DataModel.Entities;

namespace Polyathlon.ViewModels;

public class ChangeUserViewModel
{
    public virtual User CurrentUser { get; set; }

    public static ChangeUserViewModel Create()
    {
        return ViewModelSource.Create<ChangeUserViewModel>();
    }

    public void Update()
    {
    //    Settings.Settings.Data.settingsDB.UserName = CurrentUser.Login;
    //    Settings.Settings.Data.settingsDB.Password = CurrentUser.Password;

    //    Properties.Settings.Default.UserName = CurrentUser.Login;
    //    Properties.Settings.Default.Password = CurrentUser.Password;

    //    Properties.Settings.Default.Save();
    }

    [DevExpress.Mvvm.DataAnnotations.Command(false)]
    public void Init()
    {
        //CurrentUser = new(Settings.Settings.Data.settingsDB.UserName,
        //                  Settings.Settings.Data.settingsDB.Password);
    }
}
