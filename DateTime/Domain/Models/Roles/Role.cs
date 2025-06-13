using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Permissions;
using Microsoft.AspNetCore.Identity;

namespace DateTime.Domain.Models.Roles;

public class Role : IdentityRole
{
    public string BranchId { get; set; }
    public Branch Branch { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}