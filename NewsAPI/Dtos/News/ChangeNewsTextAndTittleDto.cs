using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Dtos.News
{
    public class ChangeNewsTextAndTittleDto
    {
        [Required]
        [MaxLength(30)]
        
        public string Title { get; set; }
        [Required]
        [MaxLength(1999)]
        public string Text { get; set; }
    }
}
