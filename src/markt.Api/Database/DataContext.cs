using Microsoft.EntityFrameworkCore;
using markt.Core.Entities;
using markt.Api.Database.Configurations;

namespace markt.Api.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<CartCampaigns> CartCampaigns { get; set; }
        public DbSet<CartCoupons> CartCoupons { get; set; }
        public DbSet<CategoryProducts> CategoryProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new CartEntityConfiguration());
            builder.ApplyConfiguration(new CampaignEntityConfiguration());
            builder.ApplyConfiguration(new CouponEntityConfiguration());
            builder.ApplyConfiguration(new CartProductsEntityConfiguration());
            builder.ApplyConfiguration(new CartCampaignsEntityConfiguration());
            builder.ApplyConfiguration(new CartCouponsEntityConfiguration());
            builder.ApplyConfiguration(new CategoryProductsEntityConfiguration());
        }
    }
}