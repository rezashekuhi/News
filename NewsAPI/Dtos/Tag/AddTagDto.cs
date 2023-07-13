using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Dtos.Tag
{
    public class AddTagDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
