using CalendarService.Models;
using Microsoft.EntityFrameworkCore;

namespace CalendarService.Repositories
{
  public class UsersRepository
  {
    private readonly CalendarDbContext context;

    public UsersRepository(CalendarDbContext context)
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