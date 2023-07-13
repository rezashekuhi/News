using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsAPI.Entities;

namespace NewsAPI.EntityMaps
{
    internal class CityEntityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> _)
        {
            _.ToTable("Cities");
            _.HasKey("Id");
            _.Property(_ => _.Id)
                .ValueGeneratedOnAdd();
            _.Property(_ => _.Name)
                  .IsRequired(true)
                .HasMaxLength(30);
            
                
        }
    }
}
