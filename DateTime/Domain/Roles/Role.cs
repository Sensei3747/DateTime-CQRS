using DateTime.Domain.Permissions;

namespace DateTime.Domain.Roles;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}