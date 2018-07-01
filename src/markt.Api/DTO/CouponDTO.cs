using markt.Core.Enums;

namespace markt.Api.DTO
{
    public class CouponDTO
    {
        public double MinimumAmount { get; set; }
        public double DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
    }
}