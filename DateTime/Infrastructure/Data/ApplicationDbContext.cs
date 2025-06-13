using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Participants;
using DateTime.Domain.Models.Permissions;
using DateTime.Domain.Models.Roles;
using DateTime.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;


namespace DateTime.Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<UserPermission> UserPermissions => Set<UserPermission>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Participant> Participants => Set<Participant>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    
}