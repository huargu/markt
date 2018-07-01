using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markt.Api.Database.Configurations
{
    public class CartEntityConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(cr => cr.CartId);

            builder.HasMany(pd => pd.Products);

            builder.HasMany(cp => cp.Campaigns);

            builder.HasMany(cp => cp.Coupons);
        }
    }
}