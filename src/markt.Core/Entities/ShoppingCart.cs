using System.Collections.Generic;
using markt.Core.Interfaces;
using System.Linq;
using markt.Core.Enums;

namespace markt.Core.Entities
{
    public class ShoppingCart : IShoppingCart
    {
        public int CartId { get; set; }
        public double CartPrice { get; set; }
        public ICollection<IProduct> Products { get; set; }
        public ICollection<ICampaign> Campaigns { get; set; }
        public ICollection<ICoupon> Coupons { get; set; }

        public ShoppingCart()
        {
            Products = new List<IProduct>();
            Campaigns = new List<ICampaign>();
            Coupons = new List<ICoupon>();
            CartPrice = 0;
        }
        public void AddItem(Product _product)
        {
            Products.Add(_product);
            CartPrice += _product.Price;
        }

        public void applyDiscounts(params ICampaign[] campaigns)
        {
            foreach(var item in campaigns)
            {
                Campaigns.Add(item);
            }
        }

        public void applyCoupon(ICoupon coupon)
        {
            Coupons.Add(coupon);
        }

        public double getTotalAmountAfterDiscounts()
        {
            double totalPrice = CartPrice - getCampaignDiscount();
            totalPrice = - getCouponDiscount();
            return totalPrice;
        }

        public double getCouponDiscount()
        {
            double couponDiscount = 0;

            foreach(var coupon in Coupons)
            {
                if (CartPrice >= coupon.MinimumAmount)
                {
                    if (coupon.DiscountType == DiscountType.Amount)
                    {
                        couponDiscount += coupon.DiscountValue;
                    }
                    else {
                        couponDiscount += CartPrice * coupon.DiscountValue;
                    }
                }
            }

            return couponDiscount;
        }

        public double getCampaignDiscount()
        {
            double campaignDiscount = 0;

            foreach(var campaign in Campaigns)
            {
                int campCatCount = Products.Count(x => x.Category.Equals(campaign.Category));
                double campCatValue = Products.Where(x => x.Category.Equals(campaign.Category)).Sum(x => x.Price);

                if (campCatCount >= campaign.MinimumCount)
                {
                    if(campaign.DiscountType == DiscountType.Amount)
                    {
                        campaignDiscount += campaign.DiscountValue;
                    }
                    else {
                        campaignDiscount += campCatValue * campaign.DiscountValue;
                    }
                }
            }

            return campaignDiscount;
        }

        public double getDeliveryCost()
        {
            return 0;
        }
    }
}