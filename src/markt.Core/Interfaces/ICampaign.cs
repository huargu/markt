using markt.Core.Entities;
using markt.Core.Enums;

namespace markt.Core.Interfaces
{
    public interface ICampaign
    {
        int CampaignId { get; set;}
        Category Category { get; set; }
        double DiscountValue { get; set; }
        int MinimumCount { get; set; }
        DiscountType DiscountType { get; set; }
    }
}