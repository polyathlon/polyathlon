using System.ComponentModel.DataAnnotations;

namespace Polyathlon.Models.Entities;

public record User
{
    [Required]
    public string Login { get; set; }
    public string Password { get; set; }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }
}