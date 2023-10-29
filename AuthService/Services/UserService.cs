using System.Text.Json;
using AuthService.Models;
using AuthService.Repositories;
using Azure.Messaging.ServiceBus;

namespace AuthService.Services
{
  public class UserService
  {
    private readonly UsersRepository usersRepository;
    private readonly ServiceBusClient busClient;

    public UserService(UsersRepository usersRepository)
    {
      this.usersRepository = usersRepository;
      string busConnectionString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION")!;
      this.busClient = new ServiceBusClient(busConnectionString);
    }
    public async Task<IList<User>> GetUsers()
    {
      return await this.usersRepository.Get();
    }

    public async Task<User> AddUser(User user)
    {
      ServiceBusSender sender = this.busClient.CreateSender("user_create");
      var addedUser = await this.usersRepository.Add(user);
      await sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(addedUser)));
      return addedUser;
    }
  }
}