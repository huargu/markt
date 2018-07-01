using markt.Core.Entities;

namespace markt.Core.Interfaces
{
    public interface ICartCoupons
    {
         int CartId { get; set; }
         ShoppingCart Cart { get; set; }
         int CouponId { get; set; }
         Coupon Coupon { get; set; }
    }
}