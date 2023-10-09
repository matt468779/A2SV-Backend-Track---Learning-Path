using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


public class PostManager
{
    private readonly BlogContext _context;

    public PostManager(BlogContext context)
    {
        _context = context;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public Post CreatePost(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }

    public Post GetPostById(int postId)
    {
        return _context.Posts
            .Include(p => p.Comments)
            .SingleOrDefault(p => p.PostId == postId);
    }

    public Post[] GetAllPosts()
    {
        return _context.Posts.Include(p => p.Comments).ToArray();
    }

    public void UpdatePost(Post post)
    {
        _context.Posts.Update(post);
        _context.SaveChanges();
    }

    public void DeletePost(int postId)
    {
        var post = _context.Posts.Find(postId);
        if (post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
