using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DateTime.Domain.Permissions;

namespace DateTime.Infrastructure.EntityConfigurations;

public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission> 
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.HasKey(up => new { up.UserId, up.PermissionId });
        builder.HasOne(up => up.User).WithMany(u => u.UserPermissions).HasForeignKey(up => up.UserId);
        builder.HasOne(up => up.Permission).WithMany().HasForeignKey(up => up.PermissionId);
    }
}
