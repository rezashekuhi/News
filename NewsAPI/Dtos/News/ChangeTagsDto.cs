namespace NewsAPI.Dtos.News
{
    public class ChangeTagsDto
    {
        public List<int> NewTagIds { get; set; } = new();
        public List<int> DeleteTagIds { get; set; } = new();
    }
}
