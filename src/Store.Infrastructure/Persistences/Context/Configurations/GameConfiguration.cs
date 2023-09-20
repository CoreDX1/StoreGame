using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(
        Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Game> builder
    )
    {
        builder.HasKey(e => e.GameId).HasName("game_pkey");

        builder.ToTable("Games");

        builder.Property(e => e.GameId).HasColumnName("GameId");
        builder.Property(e => e.Description).HasMaxLength(500).HasColumnName("Description");
        builder.Property(e => e.DeveloperId).HasColumnName("DeveloperId");
        builder.Property(e => e.Imagen).HasMaxLength(255).HasColumnName("Imagen");
        builder.Property(e => e.PlatformId).HasColumnName("PlatformId");
        builder.Property(e => e.Price).HasPrecision(10, 2).HasColumnName("Price");
        builder.Property(e => e.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(e => e.Stock).HasColumnName("Stock");
        builder.Property(e => e.Title).HasMaxLength(100).HasColumnName("Title");

        builder
            .HasOne(d => d.Developer)
            .WithMany(p => p.Games)
            .HasForeignKey(d => d.DeveloperId)
            .HasConstraintName("fk_developer");

        builder
            .HasOne(d => d.Platform)
            .WithMany(p => p.Games)
            .HasForeignKey(d => d.PlatformId)
            .HasConstraintName("fk_platform");

        builder
            .HasMany(d => d.Genres)
            .WithMany(p => p.Games)
            .UsingEntity<Dictionary<string, object>>(
                "GameGenre",
                r =>
                    r.HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("game_genre_genre_id_fkey"),
                l =>
                    l.HasOne<Game>()
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("game_genre_game_id_fkey"),
                j =>
                {
                    j.HasKey("GameId", "GenreId").HasName("game_genre_pkey");
                    j.ToTable("game_genre");
                }
            );
    }
}
