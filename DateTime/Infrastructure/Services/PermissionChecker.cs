// using DateTime.Application.Abstractions.Services;
// using DateTime.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// namespace DateTime.Infrastructure.Services;

// public class PermissionChecker : IPermissionChecker
// {
//   private readonly ApplicationDbContext _ctx;
//   public PermissionChecker(ApplicationDbContext ctx) => _ctx = ctx;

//   public async Task<bool> HasPermissionAsync(string userId, string perm)
//   {
//     var user = await _ctx.Users
//       .Include(u => u.Role).ThenInclude(r => r.RolePermissions).ThenInclude(rp => rp.Permission)
//       .Include(u => u.UserPermissions).ThenInclude(up => up.Permission)
//       .FirstOrDefaultAsync(u => u.Id == userId);
//     if (user == null) return false;

//     var rolePerms = user.Role.RolePermissions.Select(rp => rp.Permission.Name);
//     var userPerms = user.UserPermissions.Select(up => up.Permission.Name);
//     return rolePerms.Concat(userPerms).Contains(perm);
//   }
// }
