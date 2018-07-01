using markt.Core.Entities;

namespace markt.Core.Interfaces
{
    public interface ICartCampaigns
    {
         int CartId { get; set; }
         ShoppingCart Cart { get; set; }
         int CampaignId { get; set; }
         Campaign Campaign { get; set; }
    }
}