using Microsoft.AspNetCore.Mvc;
using threadslite.API.Data;
using threadslite.API.Models;

namespace threadslite.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    public UsersController(AppDbContext context) => _context = context;

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserCreateDto dto)
    {
        var user = new User { Username = dto.Username };
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetUsers() => Ok(_context.Users.ToList());
}
