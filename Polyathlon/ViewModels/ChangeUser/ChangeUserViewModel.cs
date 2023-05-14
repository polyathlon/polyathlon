using DevExpress.Mvvm.POCO;

using Polyathlon.Models.Entities;

namespace Polyathlon.ViewModels;

public class ChangeUserViewModel
{
    public User CurrentUser { get; set; }

    public static ChangeUserViewModel Create()
    {
        return ViewModelSource.Create<ChangeUserViewModel>();
    }

    public void Update()
    {
        Properties.ConnectionSettings.Default.UserName = CurrentUser.Login;
        Properties.ConnectionSettings.Default.Password = CurrentUser.Password;

        Properties.ConnectionSettings.Default.Save();
    }

    [DevExpress.Mvvm.DataAnnotations.Command(false)]
    public void Init()
    {
        CurrentUser = new(Properties.ConnectionSettings.Default.UserName,
                          Properties.ConnectionSettings.Default.Password);
    }
}