using markt.Core.Enums;

namespace markt.Core.Interfaces
{
    public interface ICampaign
    {
        int CampaignId { get; set;}
        ICategory Category { get; set; }
        double DiscountValue { get; set; }
        int MinimumCount { get; set; }
        DiscountType DiscountType { get; set; }
    }
}