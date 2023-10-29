using AuthService.Models;
using AuthService.Repositories;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly ILogger<UsersController> logger;
    private readonly UserService userService;

    public UsersController(
        UserService userService,
        ILogger<UsersController> logger)
    {
      this.logger = logger;
      this.userService = userService;
    }

    [HttpGet()]
    public async Task<ActionResult<IList<User>>> Get()
    {
      return Ok(await this.userService.GetUsers());
    }

    [HttpPost()]
    public async Task<ActionResult<User>> Post([FromBody] User user)
    {
      return Ok(await this.userService.AddUser(user));
    }

  }
}
