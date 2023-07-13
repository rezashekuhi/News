using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.EntityMaps
{
    public class CategoryEntityMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> _)
        {
            _.ToTable("Categories");
            _.HasKey("Id");
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.Name)
                .IsRequired(true)
                .HasMaxLength(30);
        
        }
    }
}
