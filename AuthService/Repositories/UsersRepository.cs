using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
  public class UsersRepository
  {
    private readonly AuthContext context;

    public UsersRepository(AuthContext context)
    {
      this.context = context;
    }

    public async Task<IList<User>> Get() => await this.context.Users.ToListAsync();

    public async Task<User> Add(User user)
    {
      await this.context.Users.AddAsync(user);
      await this.context.SaveChangesAsync();
      return user;
    }

  }

}