using Microsoft.EntityFrameworkCore;

namespace Store.Domain.Entities;

public partial class StoregameContext : DbContext
{
    public StoregameContext() { }

    public StoregameContext(DbContextOptions<StoregameContext> options)
        : base(options) { }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=storegame;Username=postgres;Password=index"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("cart_pkey");

            entity.ToTable("cart");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fk_customer");

            entity
                .HasOne(d => d.Game)
                .WithMany(p => p.Carts)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("fk_game");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Address).HasMaxLength(200).HasColumnName("address");
            entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(50).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasMaxLength(50).HasColumnName("last_name");
            entity.Property(e => e.Phone).HasMaxLength(20).HasColumnName("phone");
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.HasKey(e => e.DeveloperId).HasName("developer_pkey");

            entity.ToTable("developer");

            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity.Property(e => e.Website).HasMaxLength(100).HasColumnName("website");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("game_pkey");

            entity.ToTable("game");

            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Description).HasMaxLength(500).HasColumnName("description");
            entity.Property(e => e.DeveloperId).HasColumnName("developer_id");
            entity.Property(e => e.Imagen).HasMaxLength(255).HasColumnName("imagen");
            entity.Property(e => e.PlatformId).HasColumnName("platform_id");
            entity.Property(e => e.Price).HasPrecision(10, 2).HasColumnName("price");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Title).HasMaxLength(100).HasColumnName("title");

            entity
                .HasOne(d => d.Developer)
                .WithMany(p => p.Games)
                .HasForeignKey(d => d.DeveloperId)
                .HasConstraintName("fk_developer");

            entity
                .HasOne(d => d.Platform)
                .WithMany(p => p.Games)
                .HasForeignKey(d => d.PlatformId)
                .HasConstraintName("fk_platform");

            entity
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
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("genre_pkey");

            entity.ToTable("genre");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.PlatformId).HasName("platform_pkey");

            entity.ToTable("platform");

            entity.Property(e => e.PlatformId).HasColumnName("platform_id");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("transaction_pkey");

            entity.ToTable("transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.TotalAmount).HasPrecision(10, 2).HasColumnName("total_amount");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fk_customer");

            entity
                .HasOne(d => d.Game)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("fk_game");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
