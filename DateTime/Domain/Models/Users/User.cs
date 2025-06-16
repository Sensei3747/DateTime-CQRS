using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Permissions;
using DateTime.Domain.Models.Roles;
using Microsoft.AspNetCore.Identity;

namespace DateTime.Domain.Models.Users;
public class User : IdentityUser<string>
{
    public string BranchId { get; set; }
    public Branch Branch { get; set; }
    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    public User()
    {
    }

    public User(string name, string email, string branchId)
    {
        Id = Guid.NewGuid().ToString();
        UserName = name;
        Email = email;
        BranchId = branchId;
    }

    public static User Create(string name, string email, string branchId)
    {
        var user = new User(name, email, branchId);
        return user;
    }
}