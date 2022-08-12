namespace Polyathlon.DataModel.Entities;

public record User
{
    public string Login { get; set; }
    public string Password { get; set; }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }
}
