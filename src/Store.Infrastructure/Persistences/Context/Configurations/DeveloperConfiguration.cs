using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.HasKey(e => e.DeveloperId).HasName("developer_pkey");

        builder.ToTable("Developers");

        builder.Property(e => e.DeveloperId).HasColumnName("DeveloperId");
        builder.Property(e => e.Name).HasMaxLength(50).HasColumnName("Name");
        builder.Property(e => e.Website).HasMaxLength(100).HasColumnName("Website");
    }
}
