using markt.Core.Enums;

namespace markt.Core.Interfaces
{
    public interface ICoupon
    {
        int CouponId { get; set; }
        double MinimumAmount { get; set; }
        double DiscountValue { get; set; }
        DiscountType DiscountType { get; set; }
    }
}