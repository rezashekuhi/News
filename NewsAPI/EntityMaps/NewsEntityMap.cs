using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.EntityMaps
{
    public class NewsEntityMap : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> _)
        {
            _.ToTable("News");
            _.HasKey("Id");
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_=>_.Title)
                .IsRequired(true)
                .HasMaxLength(30);
            _.Property(_ => _.Text)
                .IsRequired(true)
                .HasMaxLength(1999);
            _.Property(_ => _.Date)
                .IsRequired(true);
            _.Property(_ => _.IsSlider)
                .IsRequired(true);
            _.Property(_ => _.View)
                .IsRequired(true);
            _.Property(_ => _.CityId)
                .IsRequired(true);
            _.Property(_ => _.CategoryId)
                .IsRequired(true);
            _.HasOne(_ => _.Category)
                .WithMany(_ => _.News)
                .HasForeignKey(_ => _.CategoryId);
                




        }
    }
}
