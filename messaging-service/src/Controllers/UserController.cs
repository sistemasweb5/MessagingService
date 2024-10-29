using MessagingService.src.Data;
using MessagingService.src.Domain;
using MessagingService.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(UserRepository userManager) : ControllerBase
{

    private readonly UserRepository _userManager = userManager;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _userManager.GetById(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userManager.GetAllAsync();
        return users == null ? NotFound() : Ok(users);
    }

    [HttpGet("login")]
    public async Task<IActionResult> isLogged()
    {
        string user = UserContext.CurrentUserName;
        return string.IsNullOrEmpty(user) ? NotFound() : Ok(user);
    }

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        var createdUser = await _userManager.InsertAsync(user);
        return createdUser == null ? BadRequest() : Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserModel InputUser)
    {
        var user = await _userManager.GetUserByEmail(InputUser.Email);
        if (user == null)
        {
            return NotFound();
        }
        if (user.Email == InputUser.Email && user.Password == InputUser.Password)
        {
            UserContext.CurrentUserName = user.UserName;
            return Ok(UserContext.CurrentUserName);
        }
        return BadRequest();
    }


}
