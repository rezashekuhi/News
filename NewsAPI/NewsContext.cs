using Microsoft.EntityFrameworkCore;
using NewsAPI.Entities;

namespace NewsAPI
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> _) : base(_)
        {
        }


        protected override void OnModelCreating(ModelBuilder _)
        {
            base.OnModelCreating(_);
            _.ApplyConfigurationsFromAssembly(typeof(NewsContext).Assembly);
        }

        public DbSet <News> News { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <City> Cities { get; set; }
        public DbSet <NewsComment> NewsComments { get; set; }
        public DbSet <NewsTag> NewsTags { get; set; }
        public DbSet <Tag> Tags { get; set; }





    }
}
