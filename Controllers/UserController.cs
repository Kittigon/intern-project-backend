using Microsoft.AspNetCore.Mvc;
using MyApi.DTOs;
using MyApi.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext db;

    public UsersController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = db.Users
            .Select(u => new
            {
                u.Id,
                u.Name,
                u.Email,
                u.IsActive,
                u.CreatedAt
            })
            .ToList();

        return Ok(users);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDto dto)
    {
        var user = new UserModel
        {
            Name = dto.Name,
            Email = dto.Email,
            IsActive = dto.IsActive,
            CreatedAt = DateTime.Now
        };

        db.Users.Add(user);
        db.SaveChanges();

        return Ok(new
        {
            user.Id,
            user.Name,
            user.Email,
            user.IsActive,
            user.CreatedAt
        });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id , [FromBody] UpdateUserDto dto)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);

        if(user == null)
        {
            return NotFound(new {message = "User Not Found"});
        }

        user.Name = dto.Name;
        user.Email = dto.Email;
        user.IsActive = dto.IsActive;

        db.SaveChanges();

        return Ok(new
        {
            user.Id,
            user.Name,
            user.Email,
            user.IsActive,
            user.CreatedAt
        });
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveUser(int id)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);

        if(user == null)
        {
            return NotFound(new { message = "User not Found"});
        }

        db.Users.Remove(user);
        db.SaveChanges();

        return Ok(new {message = "User deleted Successfully"});
    }
}

