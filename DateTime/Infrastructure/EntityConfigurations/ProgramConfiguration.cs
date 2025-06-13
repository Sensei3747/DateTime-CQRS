using DateTime.Domain.Models.Program;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DateTime.Infrastructure.EntityConfigurations;

public class ProgramConfiguration : IEntityTypeConfiguration<Programs>
{
    public void Configure(EntityTypeBuilder<Programs> builder)
    {
        builder.ToTable("Programs");
        builder.HasKey(program => program.Id);
        builder.Property(program => program.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();
        builder.Property(program => program.Name)
               .HasMaxLength(100)
               .IsRequired();
        builder.Property(program => program.Location)
               .HasMaxLength(100)
               .IsRequired();
        builder.Property(program => program.StartTime)
               .IsRequired();
        builder.Property(program => program.EndTime)
               .IsRequired();
        builder.Property(program => program.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();
        builder.Property(program => program.Limit)
               .IsRequired();

        builder.HasMany(program => program.Registrations)
               .WithOne(reg => reg.Program)
               .HasForeignKey(reg => reg.ProgramId);     
           
    }
}