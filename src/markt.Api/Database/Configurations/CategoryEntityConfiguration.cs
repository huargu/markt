using markt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markt.Api.Database.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(ct => ct.CategoryId);

            builder.HasOne(ct => ct.ParentCategory)
                .WithMany()
                .HasForeignKey(ct => ct.ParentCategoryId);
        }
    }
}