using markt.Core.Enums;
using markt.Core.Interfaces;

namespace markt.Core.Entities
{
    public class Campaign : ICampaign
    {
        public int CampaignId { get; set; }
        public Category Category { get; set; }
        public double DiscountValue { get; set; }
        public int MinimumCount { get; set; }
        public DiscountType DiscountType { get; set; }

        protected Campaign() {}

        public Campaign(Category _cat, double _value, int _count, DiscountType _type)
        {
            Category = _cat;
            DiscountValue = _value;
            MinimumCount = _count;
            DiscountType = _type;
        }
    }
}