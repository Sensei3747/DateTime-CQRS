using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Permissions;
using DateTime.Domain.Models.Roles;
using Microsoft.AspNetCore.Identity;

namespace DateTime.Domain.Models.Users;
public class User : IdentityUser
{
    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    public User()
    {
    }

    public User(string name, string passhash, string email)
    {
        UserName = name;
        PasswordHash = passhash;
        Email = email;
    }

    public static User Create(string name, string passhash, string email)
    {
        var user = new User(name, passhash, email);
        return user;
    }
}