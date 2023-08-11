using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(e => e.PlatformId).HasName("platform_pkey");

        builder.ToTable("platform");

        builder.Property(e => e.PlatformId).HasColumnName("platform_id");
        builder.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
    }
}
