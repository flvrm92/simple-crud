using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class SubCategoryMap : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategory");
            builder.HasKey(i => i.Id);

            builder.HasMany(i => i.Products)
                .WithOne(o => o.SubCategory)
                .HasForeignKey(i => i.SubCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
