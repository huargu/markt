using markt.Core.Enums;
using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class Coupon : ICoupon
    {
        public int CouponId { get; set; }
        public double MinimumAmount { get; set; }
        public double DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }

        protected Coupon() {}

        public Coupon(double _amount, double _value, DiscountType _type)
        {
            MinimumAmount = _amount;
            DiscountValue = _value;
            DiscountType =_type;
        }
    }
}