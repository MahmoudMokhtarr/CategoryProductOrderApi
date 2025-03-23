using CategoryProductOrderApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CategoryProductOrderApi.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.OrderID).IsRequired()
                .ValueGeneratedOnAdd();
            builder.HasKey(o => o.OrderID);

            builder.Property(o => o.OrderDate).HasColumnType("DateTime")
                .IsRequired();

            builder.Property(O => O.CustomerName).HasColumnType("NVARCHAR")
                .HasMaxLength(150).
                IsRequired();

            builder.ToTable("Orders");
        }
    }
}