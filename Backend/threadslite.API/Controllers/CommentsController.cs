using Microsoft.AspNetCore.Mvc;
using threadslite.API.Data;
using threadslite.API.Models;

namespace threadslite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public CommentsController(AppDbContext context) => _context = context;

    [HttpPost]
    public IActionResult CreateComment([FromBody] CommentCreateDto dto)
    {
        var post = _context.Posts.Find(dto.PostId);
        if (post == null) return NotFound("Post not found");

        var comment = new Comment { Text = dto.Text, PostId = dto.PostId, Post = post };
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return Ok(comment);
    }

    [HttpGet]
    public IActionResult GetComments() => Ok(_context.Comments.ToList());
}
