using DateTime.Application.Abstractions.Auth;
using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Participants;
using DateTime.Domain.Models.Permissions;
using DateTime.Domain.Models.Roles;
using DateTime.Domain.Models.Users;
using DateTime.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace DateTime.Infrastructure.Seeders;

public static class DbSeeder
{
  public static async Task SeedAsync(ApplicationDbContext ctx, IPasswordHasher pass, UserManager<User> manager)
  {
    if (!ctx.Permissions.Any())
    {
      var perms = new[] { "ListParticipants", "CreateParticipant", "ViewParticipant", "RemoveParticipant", "AccessFinancialDetails" }
                  .Select(n => new Permission { Id = Guid.NewGuid().ToString(), Name = n }).ToList();
      ctx.Permissions.AddRange(perms);
      await ctx.SaveChangesAsync();
    }

    var id = Guid.NewGuid().ToString();
    if (!ctx.Branches.Any())
    {
      ctx.Branches.Add(new Branch { Id = id, Name = "Main Branch", LocationGroup = "Zone A" });
      await ctx.SaveChangesAsync();
    }

    if (!ctx.Roles.Any())
    {
      var roles = new[] { "Admin", "BranchManager", "Staff" }
                  .Select(n => new Role { Id = Guid.NewGuid().ToString(), Name = n, NormalizedName = n.ToUpper()}).ToList();
      ctx.Roles.AddRange(roles);
      await ctx.SaveChangesAsync();
    }
    
    if (!ctx.RolePermissions.Any())
    {
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

    if (!ctx.Users.Any())
    {
      var admin = ctx.Roles.Single(r => r.Name == "Admin");
      var branch = ctx.Branches.First();
      var user = new User { Id = Guid.NewGuid().ToString(), UserName = "Super Admin", Email = "admin@gmail.com", BranchId = id };
      var result = await manager.CreateAsync(user, "1234");
      if (result.Succeeded)
      {
        var savedUser = await manager.FindByEmailAsync(user.Email);
        await manager.AddToRoleAsync(user, admin.Name);
      }
      else
      {
        throw new Exception("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
      }
    }

    if (!ctx.Participants.Any())
    {
      var user = ctx.Users.First();
      var branch = ctx.Branches.First();

      ctx.Participants.Add(new Participant
      {
        Name = "Test User",
        BranchId = branch.Id,
        CreatedByUserId = user.Id
      });

      await ctx.SaveChangesAsync();
    }
  }
}
