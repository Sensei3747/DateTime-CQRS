using DateTime.Domain.Permissions;
using DateTime.Domain.Roles;
using DateTime.Infrastructure.Data;

namespace DateTime.Infrastructure.Seeders;

public static class DbSeeder {
  public static async Task SeedAsync(ApplicationDbContext ctx) {
    if (!ctx.Permissions.Any()) {
      var perms = new[] { "ListParticipants", "CreateParticipant", "ViewParticipant", "RemoveParticipant", "AccessFinancialDetails" }
                  .Select(n => new Permission { Id = Guid.NewGuid(), Name = n }).ToList();
      ctx.Permissions.AddRange(perms);
      await ctx.SaveChangesAsync();
    }

    if (!ctx.Roles.Any()) {
      var roles = new[] { "Admin", "BranchManager", "Staff" }
                  .Select(n => new Role { Id = Guid.NewGuid(), Name = n }).ToList();
      ctx.Roles.AddRange(roles);
      await ctx.SaveChangesAsync();
    }

    if (!ctx.Branches.Any()) {
      ctx.Branches.Add(new Domain.Branches.Branch { Id = Guid.NewGuid(), Name = "Main Branch", LocationGroup = "Zone A" });
      await ctx.SaveChangesAsync();
    }

    if (!ctx.RolePermissions.Any()) {
      var perms = ctx.Permissions.ToList();
      var roles = ctx.Roles.ToList();

      var admin = roles.Single(r => r.Name == "Admin");
      ctx.RolePermissions.AddRange(perms.Select(p => new RolePermission { RoleId = admin.Id, PermissionId = p.Id }));

      var bm = roles.Single(r => r.Name == "BranchManager");
      ctx.RolePermissions.AddRange(perms.Where(p => p.Name != "AccessFinancialDetails" && p.Name != "RemoveParticipant")
            .Select(p => new RolePermission { RoleId = bm.Id, PermissionId = p.Id }));

      var st = roles.Single(r => r.Name == "Staff");
      ctx.RolePermissions.AddRange(perms.Where(p => new[] { "ListParticipants", "ViewParticipant" }.Contains(p.Name))
            .Select(p => new RolePermission { RoleId = st.Id, PermissionId = p.Id }));

      await ctx.SaveChangesAsync();
    }

    if (!ctx.Users.Any()) {
      var admin = ctx.Roles.Single(r => r.Name == "Admin");
      var branch = ctx.Branches.First();
      ctx.Users.Add(new Domain.Users.User { Id = Guid.NewGuid(), Name = "Super Admin", RoleId = admin.Id, BranchId = branch.Id });
      await ctx.SaveChangesAsync();
    }
  }
}
