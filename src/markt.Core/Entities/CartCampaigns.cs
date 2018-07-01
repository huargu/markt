using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class CartCampaigns : ICartCampaigns
    {
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}