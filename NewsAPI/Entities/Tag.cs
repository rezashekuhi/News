namespace NewsAPI.Entities
{
    public class Tag
    {
        public Tag()
        {
            NewsTags=new HashSet<NewsTag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<NewsTag> NewsTags { get; set; }
    }
}