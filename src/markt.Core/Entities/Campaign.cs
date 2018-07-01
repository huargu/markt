using markt.Core.Enums;
using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class Campaign : ICampaign
    {
        public int CampaignId { get; set; }
        public ICategory Category { get; set; }
        public double DiscountValue { get; set; }
        public int MinimumCount { get; set; }
        public DiscountType DiscountType { get; set; }
        public Campaign(ICategory _cat, double _value, int _count, DiscountType _type)
        {
            Category = _cat;
            DiscountValue = _value;
            MinimumCount = _count;
            DiscountType = _type;
        }
    }
}