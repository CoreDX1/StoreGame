using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistences.Context.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.CustomerId).HasName("customer_pkey");

        builder.ToTable("customer");

        builder.Property(e => e.CustomerId).HasColumnName("customer_id");
        builder.Property(e => e.Address).HasMaxLength(200).HasColumnName("address");
        builder.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
        builder.Property(e => e.FirstName).HasMaxLength(50).HasColumnName("first_name");
        builder.Property(e => e.LastName).HasMaxLength(50).HasColumnName("last_name");
        builder.Property(e => e.Phone).HasMaxLength(20).HasColumnName("phone");
    }
}
