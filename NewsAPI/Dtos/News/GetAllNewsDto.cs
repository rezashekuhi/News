namespace NewsAPI.Dtos.News
{
    public class GetAllNewsDto
    {
      
        public string Title { get; set; }
       
        public int View { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public DateTime Date { get; set; }

        public List<NewsTagsDto> Tags { get; set; } = new List<NewsTagsDto>();

    }
}
