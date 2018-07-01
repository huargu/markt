using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markt.Api.Database.Configurations
{
    public class CartCouponsEntityConfiguration : IEntityTypeConfiguration<CartCoupons>
    {
        public void Configure(EntityTypeBuilder<CartCoupons> builder)
        {
            builder.ToTable("CartCoupons");

            builder.HasKey(cc => new { cc.CartId, cc.CouponId });

            builder.HasOne(cc => cc.Cart)
                .WithMany(ct => ct.Coupons)
                .HasForeignKey(cc => cc.CartId);
            
            builder.HasOne(cc => cc.Coupon)
                .WithMany()
                .HasForeignKey(cc => cc.CouponId);
        }
        
    }
}