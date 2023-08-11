using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(e => e.GenreId).HasName("genre_pkey");

        builder.ToTable("genre");

        builder.Property(e => e.GenreId).HasColumnName("genre_id");
        builder.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
    }
}
