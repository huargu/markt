using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markt.Api.Database.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(pd => pd.ProductId);

            builder.HasOne(pd => pd.Category)
                .WithMany()
                .HasForeignKey(pd => pd.CategoryId);
        }
    }
}