using CalendarService.Models;
using CalendarService.Repositories;

namespace CalendarService.Services
{
  public class UserService
  {
    private readonly UsersRepository usersRepository;

    public UserService(UsersRepository usersRepository)
    {
      this.usersRepository = usersRepository;
    }
    public async Task<IList<User>> GetUsers()
    {
      return await this.usersRepository.Get();
    }

    public async Task<User> AddUser(User user)
    {
      return await this.usersRepository.Add(user);
    }
  }
}