namespace NewsAPI.Entities
{
    public class Category
    {
        public Category()
        {
            News=new HashSet<News>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<News> News { get; set; }
    }
}
