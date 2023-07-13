using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Dtos.Category
{
    public class AddCategoryDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
