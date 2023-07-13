using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Dtos.News
{
    public class SearchOnNewsListDto
    {
        [MaxLength(30)]
        public string? Category { get; set; }

        [MaxLength(30)]
        public string? Title { get; set; }

        [MaxLength(30)]
        public string? CityName { get; set; }
    }
}