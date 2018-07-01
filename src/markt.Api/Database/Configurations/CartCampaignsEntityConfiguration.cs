using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markt.Api.Database.Configurations
{
    public class CartCampaignsEntityConfiguration : IEntityTypeConfiguration<CartCampaigns>
    {
        public void Configure(EntityTypeBuilder<CartCampaigns> builder)
        {
            builder.ToTable("CartCampaigns");

            builder.HasKey(cc => new { cc.CampaignId, cc.CartId });

            builder.HasOne(cc => cc.Cart)
                .WithMany(ct => ct.Campaigns)
                .HasForeignKey(cc => cc.CartId);
            
            builder.HasOne(cc => cc.Campaign)
                .WithMany()
                .HasForeignKey(cc => cc.CampaignId);
        }
    }
}