using CategoryProductOrderApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CategoryProductOrderApi.Configurations
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(o => o.OrderDetailID)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasKey(o => o.OrderDetailID);

            builder.Property(o => o.OrderID);
            builder.Property(o => o.ProductID);

            builder.Property(o => o.Quantity)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(o => o.UnitPrice)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.HasOne(o => o.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(o => o.OrderID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Product)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(o => o.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("OrderDetails");

        }
    }
}