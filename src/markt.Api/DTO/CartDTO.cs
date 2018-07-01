using System.Collections.Generic;

namespace markt.Api.DTO
{
    public class CartDTO
    {
        public double CartPrice { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public ICollection<CampaignDTO> Campaigns { get; set; }
        public ICollection<CouponDTO> Coupons { get; set; }
    }
}