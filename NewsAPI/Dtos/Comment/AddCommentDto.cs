using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Dtos.Comment
{
    public class AddCommentDto
    {
        [Required]
        
        public int NewsId { get; set; }
        [MaxLength(30)]

        public string UserName { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
