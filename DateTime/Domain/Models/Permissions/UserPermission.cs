using DateTime.Domain.Models.Users;

namespace DateTime.Domain.Models.Permissions;

public class UserPermission
{
    public string UserId { get; set; }
    public User User { get; set; } = null!;
    public string PermissionId { get; set; }
    public Permission Permission { get; set; } = null!;
}