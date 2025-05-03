using Microsoft.AspNetCore.Mvc;
using threadslite.API.Data;
using threadslite.API.Models;
using threadslite.API.Models.DTOs;

namespace threadslite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly AppDbContext _context;
    public PostsController(AppDbContext context) => _context = context;

    [HttpPost]
    public IActionResult CreatePost([FromBody] PostCreateDto dto)
    {
        var user = _context.Users.Find(dto.UserId);
        if (user == null) return NotFound("User not found");

        var post = new Post { Content = dto.Content, UserId = dto.UserId, User = user };
        _context.Posts.Add(post);
        _context.SaveChanges();
        return Ok(post);
    }

    [HttpGet]
    public IActionResult GetPosts() => Ok(_context.Posts.ToList());
}
