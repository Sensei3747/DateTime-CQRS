using DateTime.Domain.Roles;

namespace DateTime.Domain.Permissions;

public class RolePermission {
  public Guid RoleId { get; set; }
  public Role Role { get; set; } = null!;
  public Guid PermissionId { get; set; }
  public Permission Permission { get; set; } = null!;
}