using CategoryProductOrderApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CategoryProductOrderApi.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(b => b.ID).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CategoryName).IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID);

            builder.ToTable("Categories");

        }
    }
}