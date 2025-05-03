namespace threadslite.API.Models.DTOs
{
    public class CommentCreateDto
    {
        public string Text { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
