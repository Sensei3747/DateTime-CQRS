using DateTime.Domain.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DateTime.Infrastructure.EntityConfigurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch> 
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(bc => bc.Id);
        builder.Property(bc => bc.Name).IsRequired().HasMaxLength(100);
        builder.Property(bc => bc.LocationGroup).IsRequired().HasMaxLength(100);
    }
}
