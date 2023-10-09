using Microsoft.AspNetCore.Mvc;

namespace Blog_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly PostManager postManager;
    private BlogContext context;
    public PostController(ILogger<PostController> logger)
    {
        _logger = logger;
        context = new BlogContext();
        postManager = new PostManager(context);
    }

    [HttpGet]
    public IActionResult GetPosts()
    {
        var posts = postManager.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public IActionResult GetPostById(int id)
    {
        var postDetails = postManager.GetPostById(id);
        if (postDetails == null)
        {
            return NotFound();
        }
        return Ok(postDetails);
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] Post post)
    {
        var newPost = postManager.CreatePost(post);
        return CreatedAtAction(nameof(GetPostById), new { id = newPost.PostId }, newPost);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePost(int id, [FromBody] Post post)
    {
        var currPost = postManager.GetPostById(id);
        if (currPost == null || post.PostId != id)
        {
            return NotFound();
        }
        currPost.Title = post.Title;
        currPost.Content = post.Content;
        postManager.UpdatePost(currPost);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePost(int id)
    {
        var post = postManager.GetPostById(id);
        if (post == null)
        {
            return NotFound();
        }
        postManager.DeletePost(id);
        return NoContent();
    }
}
