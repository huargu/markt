using markt.Core.Enums;

namespace markt.Api.DTO
{
    public class CampaignDTO
    {
        public CategoryDTO Category { get; set; }
        public double DiscountValue { get; set; }
        public int MinimumCount { get; set; }
        public DiscountType DiscountType { get; set; }
    }
}