using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.HasKey(e => e.DeveloperId).HasName("developer_pkey");

        builder.ToTable("developer");

        builder.Property(e => e.DeveloperId).HasColumnName("developer_id");
        builder.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
        builder.Property(e => e.Website).HasMaxLength(100).HasColumnName("website");
    }
}
