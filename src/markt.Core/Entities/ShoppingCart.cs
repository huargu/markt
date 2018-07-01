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
        public ICollection<CartProducts> Products { get; set; }
        public ICollection<CartCampaigns> Campaigns { get; set; }
        public ICollection<CartCoupons> Coupons { get; set; }

        public ShoppingCart()
        {
            Products = new List<CartProducts>();
            Campaigns = new List<CartCampaigns>();
            Coupons = new List<CartCoupons>();
            CartPrice = 0;
        }
        public void AddItem(Product _product)
        {
            CartProducts cp = new CartProducts();
            cp.CartId = this.CartId;
            cp.Cart = this;
            cp.Product = _product;
            cp.ProductId = _product.ProductId;

            Products.Add(cp);
            CartPrice += _product.Price;
        }

        public void applyDiscounts(params Campaign[] campaigns)
        {
            foreach(var item in campaigns)
            {
                CartCampaigns cc = new CartCampaigns();
                cc.CartId = this.CartId;
                cc.Cart = this;
                cc.Campaign = item;
                cc.CampaignId = item.CampaignId;

                Campaigns.Add(cc);
            }
        }

        public void applyCoupon(Coupon coupon)
        {
            CartCoupons cc = new CartCoupons();
            cc.Cart = this;
            cc.CartId = this.CartId;
            cc.Coupon = coupon;
            cc.CouponId = coupon.CouponId;

            Coupons.Add(cc);
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
                if (CartPrice >= coupon.Coupon.MinimumAmount)
                {
                    if (coupon.Coupon.DiscountType == DiscountType.Amount)
                    {
                        couponDiscount += coupon.Coupon.DiscountValue;
                    }
                    else {
                        couponDiscount += CartPrice * coupon.Coupon.DiscountValue;
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
                int campCatCount = Products.Count(x => x.Product.Category.Equals(campaign.Campaign.Category));
                double campCatValue = Products.Where(x => x.Product.Category.Equals(campaign.Campaign.Category)).Sum(x => x.Product.Price);

                if (campCatCount >= campaign.Campaign.MinimumCount)
                {
                    if(campaign.Campaign.DiscountType == DiscountType.Amount)
                    {
                        campaignDiscount += campaign.Campaign.DiscountValue;
                    }
                    else {
                        campaignDiscount += campCatValue * campaign.Campaign.DiscountValue;
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