using DateTime.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DateTime.Infrastructure.EntityConfigurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();
        builder.Property(user => user.Email)
               .IsRequired()
               .HasMaxLength(100);
        builder.Property(user => user.PasswordHash)
               .IsRequired()
               .HasMaxLength(100);;    
    }
}