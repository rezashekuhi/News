namespace NewsAPI.Dtos.News
{
    public class DTO
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public CommentsDto CommentsDto { get; set; }
        public tagsDto tagsDto { get; set; }
    }
    public class CommentsDto
    {
        public int CommentCount { get; set; }
        public int AprovedCount { get; set; }
        public int DeclinedCount { get; set; }

        public CommentsUserAndId? CommentsUserAndId { get; set; }
    }
    public class tagsDto 
    {
        public int TagCount { get; set; }
        public List<string> TagNames { get; set; } = new();
    }
    public class CommentsUserAndId 
    {
        public int CommentId { get; set; }
        public string CommentUser { get; set; }
    }


}
