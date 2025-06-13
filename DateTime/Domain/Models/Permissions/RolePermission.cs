using DateTime.Domain.Models.Roles;

namespace DateTime.Domain.Models.Permissions;

public class RolePermission
{
  public string RoleId { get; set; }
  public Role Role { get; set; } = null!;
  public string PermissionId { get; set; }
  public bool Is_Granted { get; set; } = true;
  public Permission Permission { get; set; } = null!;
}