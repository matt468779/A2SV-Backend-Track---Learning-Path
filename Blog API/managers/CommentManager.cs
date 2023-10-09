using Microsoft.EntityFrameworkCore;

public class CommentManager
{
    private readonly BlogContext _context;

    public CommentManager(BlogContext context)
    {
        _context = context;
    }

    public void CreateComment(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    public Comment GetCommentById(int commentId)
    {
        return _context.Comments.Find(commentId);
    }

    public async Task<Comment> UpdateComment(Comment comment)
    {
        var result = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == comment.CommentId);

        if (result == null)
        {
            return null;
        }

        result.Text = comment.Text;
        result.CreatedAt = comment.CreatedAt;
        result.PostId = comment.PostId;

        _context.SaveChanges();

        return result;
    }

    public void DeleteComment(int commentId)
    {
        var comment = _context.Comments.Find(commentId);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}