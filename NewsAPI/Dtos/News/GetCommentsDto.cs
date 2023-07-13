namespace NewsAPI.Dtos.News
{
    public class GetCommentsDto
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public Boolean? IsAproved { get; set; }
    }
}
