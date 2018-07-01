using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markt.Api.Database.Configurations
{
    public class CartProductsEntityConfiguration : IEntityTypeConfiguration<CartProducts>
    {
        public void Configure(EntityTypeBuilder<CartProducts> builder)
        {
            builder.ToTable("CartProducts");

            builder.HasKey(cp => new { cp.CartId, cp.ProductId });

            builder.HasOne(ct => ct.Cart)
                .WithMany(cp => cp.Products)
                .HasForeignKey(ct => ct.CartId);

            builder.HasOne(pd => pd.Product)
                .WithMany()
                .HasForeignKey(pd => pd.ProductId);
        }
    }
}