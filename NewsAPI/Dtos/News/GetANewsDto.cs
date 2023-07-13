namespace NewsAPI.Dtos.News
{
    public class GetANewsDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public DateTime Date { get; set; }

        public List<string> AprovedComments { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();

    }
}
