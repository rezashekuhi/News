using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.EntityMaps
{
    public class NewsCommentEntityMap : IEntityTypeConfiguration<NewsComment>
    {
        public void Configure(EntityTypeBuilder<NewsComment> _)
        {
            _.ToTable("NewsComments");
            _.HasKey("Id");
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.UserName)
                .HasMaxLength(30)
                .IsRequired(true);
            _.Property(_ => _.IsAprroved)
                .IsRequired();
            _.Property(_ => _.Text)
                .IsRequired(true)
                .HasMaxLength(999);
            _.Property(_ => _.Date)
                .IsRequired(true);
            _.Property(_ => _.NewsId)
                .IsRequired(true);
            _.HasOne(_ => _.News)
                .WithMany(_ => _.NewsComments)
                .HasForeignKey(_ => _.NewsId);
                
           




        }
    }
}
