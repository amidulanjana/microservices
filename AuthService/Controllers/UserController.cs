using AuthService.Models;
using AuthService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly ILogger<UsersController> logger;
    private readonly UsersRepository usersRepository;

    public UsersController(
        UsersRepository usersRepository,
        ILogger<UsersController> logger)
    {
      this.logger = logger;
      this.usersRepository = usersRepository;
    }

    [HttpGet()]
    public async Task<ActionResult<IList<User>>> Get()
    {
      return Ok(await this.usersRepository.Get());
    }

    [HttpPost()]
    public async Task<ActionResult<User>> Post([FromBody] User user)
    {
      return Ok(await this.usersRepository.Add(user));
    }

  }
}
