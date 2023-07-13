using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.EntityMaps
{
    public class TagEntityMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> _)
        {
            _.ToTable("Tags");
            _.HasKey("Id");
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.Name)
                .IsRequired(true)
                .HasMaxLength(30);

        }
    }
}
