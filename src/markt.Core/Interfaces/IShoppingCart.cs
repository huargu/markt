using System.Collections.Generic;
using markt.Core.Entities;

namespace markt.Core.Interfaces
{
    public interface IShoppingCart
    {   
        int CartId { get; set; }
        ICollection<CartProducts> Products { get; set; }
        ICollection<CartCampaigns> Campaigns { get; set; }
        ICollection<CartCoupons> Coupons { get; set; }
        void applyDiscounts(params Campaign[] campaigns);
        void applyCoupon(Coupon coupon);
        double getTotalAmountAfterDiscounts();
        double getCouponDiscount();
        double getCampaignDiscount();
        double getDeliveryCost();
    }
}