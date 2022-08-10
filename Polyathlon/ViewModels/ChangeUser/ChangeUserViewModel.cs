using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
//using DevExpress.DevAV.Common.Utils;
//using DevExpress.DevAV.DevAVDbDataModel1;
//using DevExpress.DevAV.Common.DataModel;
//using DevExpress.DevAV;
//using DevExpress.DevAV.Common.ViewModel;
using Polyathlon.ViewModels.Common;
using Polyathlon.DbDataModel;
using Polyathlon.DataModel;


namespace Polyathlon.ViewModels
{
    public class ChangeUserViewModel
    {
        public virtual User CurrentUser { get; set; }

        public static ChangeUserViewModel Create()
        {
            return ViewModelSource.Create<ChangeUserViewModel>();
        }

        public void Update()
        {
            Settings.Settings.Data.settingsDB.UserName = CurrentUser.Login;
            Settings.Settings.Data.settingsDB.Password = CurrentUser.Password;

            Properties.Settings.Default.UserName = CurrentUser.Login;
            Properties.Settings.Default.Password = CurrentUser.Password;

            Properties.Settings.Default.Save();
        }

        [DevExpress.Mvvm.DataAnnotations.Command(false)]
        public void Init()
        {
            CurrentUser = new(Settings.Settings.Data.settingsDB.UserName,
                              Settings.Settings.Data.settingsDB.Password);
        }
    }

    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
