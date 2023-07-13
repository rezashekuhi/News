using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Dtos.News
{
    public class AddNewsDto
    {
        
        [Required]
      
        public int CategoryId { get; set; }
        [Required]
        public int CityId { get; set; }
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(1999)]

        public string Text { get; set; }
        [Required]
        public List<string> Tags { get; set; } = new();
        [Required]

        public bool IsSlider { get; set; }



    }
}
