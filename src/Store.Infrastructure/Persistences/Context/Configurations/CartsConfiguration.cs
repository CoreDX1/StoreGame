using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

public class CartsConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(e => e.CartId).HasName("cart_pkey");

        builder.ToTable("cart");

        builder.Property(e => e.CartId).HasColumnName("cart_id");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.GameId).HasColumnName("game_id");
        builder.Property(e => e.Quantity).HasColumnName("quantity");

        builder
            .HasOne(d => d.Customer)
            .WithMany(p => p.Carts)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("fk_customer");

        builder
            .HasOne(d => d.Game)
            .WithMany(p => p.Carts)
            .HasForeignKey(d => d.GameId)
            .HasConstraintName("fk_game");
    }
}
