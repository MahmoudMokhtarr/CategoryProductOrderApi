using CategoryProductOrderApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CategoryProductOrderApi.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(p => p.ID);

            builder.Property(c => c.ProductName).IsRequired()
                  .HasColumnType("VARCHAR")
                  .HasMaxLength(150)
                  .IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.StockQuantity).HasColumnType("INT")
                .IsRequired();

            builder.HasMany(p => p.Order).WithMany(p => p.Products);

            builder.ToTable("Products");
        }
    }
}