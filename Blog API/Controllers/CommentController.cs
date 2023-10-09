using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// namespace Blog.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly BlogContext context;
    private readonly ILogger<CommentController> _logger;
    private readonly CommentManager commentManager;

    public CommentController(ILogger<CommentController> logger)
    {
        context = new BlogContext();
        _logger = logger;
        context = new BlogContext();
        commentManager = new CommentManager(context);
    }

    // GET: api/comments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        return await context.Comments.ToListAsync();
    }

    // GET: api/comments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
        var comment = await context.Comments.FindAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    // POST api/comments
    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment(Comment comment)
    {
        context.Comments.Add(comment);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
    }

    // PUT api/comments/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Comment>> PutComment(int id, Comment comment)
    {
        // try
        // {
        if (id != comment.CommentId)
        {
            return BadRequest();
        }

        var commentToUpdate = commentManager.GetCommentById(id);
        if (commentToUpdate == null)
        {
            return NotFound("Comment not found with the ID");
        }

        return await commentManager.UpdateComment(comment);
        // }
        // catch (Exception)
        // {
        //     return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data");
        // }
    }

    // DELETE api/comment/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await context.Comments.FindAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        context.Comments.Remove(comment);
        await context.SaveChangesAsync();

        return Ok(comment);
    }
}