public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public virtual List<Comment> Comments { get; set; }
}