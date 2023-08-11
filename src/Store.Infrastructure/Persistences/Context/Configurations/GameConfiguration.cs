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

        builder.ToTable("game");

        builder.Property(e => e.GameId).HasColumnName("game_id");
        builder.Property(e => e.Description).HasMaxLength(500).HasColumnName("description");
        builder.Property(e => e.DeveloperId).HasColumnName("developer_id");
        builder.Property(e => e.Imagen).HasMaxLength(255).HasColumnName("imagen");
        builder.Property(e => e.PlatformId).HasColumnName("platform_id");
        builder.Property(e => e.Price).HasPrecision(10, 2).HasColumnName("price");
        builder.Property(e => e.ReleaseDate).HasColumnName("release_date");
        builder.Property(e => e.Stock).HasColumnName("stock");
        builder.Property(e => e.Title).HasMaxLength(100).HasColumnName("title");

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
