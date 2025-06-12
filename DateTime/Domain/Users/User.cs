using DateTime.Domain.Branches;
using DateTime.Domain.Permissions;
using DateTime.Domain.Roles;

namespace DateTime.Domain.Users;
public sealed class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid RoleId { get; set; }
    public Guid BranchId { get; set; }
    public Role Role { get; set; } = null!;
    public Branch Branch { get; set; } = null!;
    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    private User()
    {
    }

    private User(string name)
    {
        Name = name;
    }

    public static User Create(string name)
    {
        var user = new User(name);
        return user;
    }
}