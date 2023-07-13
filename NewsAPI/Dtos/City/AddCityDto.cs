using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Dtos.City
{
    public class AddCityDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
