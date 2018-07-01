using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class CartCoupons : ICartCoupons
    {
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}