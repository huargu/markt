using System.Collections.Generic;

namespace markt.Core.Interfaces
{
    public interface IShoppingCart
    {   
        int CartId { get; set; }
        ICollection<IProduct> Products { get; set; }
        ICollection<ICampaign> Campaigns { get; set; }
        ICollection<ICoupon> Coupons { get; set; }
        void applyDiscounts(params ICampaign[] campaigns);
        void applyCoupon(ICoupon coupon);
        double getTotalAmountAfterDiscounts();
        double getCouponDiscount();
        double getCampaignDiscount();
        double getDeliveryCost();
    }
}