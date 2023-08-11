using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(e => e.TransactionId).HasName("transaction_pkey");

        builder.ToTable("transaction");

        builder.Property(e => e.TransactionId).HasColumnName("transaction_id");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.GameId).HasColumnName("game_id");
        builder.Property(e => e.TotalAmount).HasPrecision(10, 2).HasColumnName("total_amount");
        builder.Property(e => e.TransactionDate).HasColumnName("transaction_date");

        builder
            .HasOne(d => d.Customer)
            .WithMany(p => p.Transactions)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("fk_customer");

        builder
            .HasOne(d => d.Game)
            .WithMany(p => p.Transactions)
            .HasForeignKey(d => d.GameId)
            .HasConstraintName("fk_game");
    }
}
