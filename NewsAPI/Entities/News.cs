namespace NewsAPI.Entities
{
    public class News
    {
        public News()
        {
            NewsComments = new();
            NewsTags = new();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Boolean IsSlider { get; set; }
        public int View { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public HashSet<NewsComment> NewsComments { get; set; }
        public HashSet<NewsTag> NewsTags { get; set; }
    }

    public class NewsDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
    }
}