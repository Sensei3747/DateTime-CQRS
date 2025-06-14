using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Permissions;
using Microsoft.AspNetCore.Identity;

namespace DateTime.Domain.Models.Roles;

public class Role : IdentityRole
{
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}