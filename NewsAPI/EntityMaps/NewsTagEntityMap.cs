using Microsoft.EntityFrameworkCore;
using NewsAPI.Entities;

namespace NewsAPI.EntityMaps
{
    public class NewsTagEntityMap : IEntityTypeConfiguration<NewsTag>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NewsTag> _)
        {
            _.ToTable("NewsTags");
            _.HasKey(_ => new
            {
                _.NewsId,
                _.TagId
            });


            _.HasOne(_ => _.News)
                .WithMany(_ => _.NewsTags)
                .HasForeignKey(_ => _.NewsId);
            _.HasOne(_=>_.Tag)
                .WithMany(_=>_.NewsTags)
                .HasForeignKey(_ => _.TagId);
                

        }
    }
}
