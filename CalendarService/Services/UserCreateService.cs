using System.Text.Json;
using Azure.Messaging.ServiceBus;
using CalendarService.Models;

namespace CalendarService.Services
{
  public class UserCreateService : BackgroundService
  {
    private readonly IServiceScopeFactory serviceScopeFactory;
    private ServiceBusClient busClient;
    private ServiceBusProcessor processor;

    public UserCreateService(IServiceScopeFactory serviceScopeFactory)
    {
      this.serviceScopeFactory = serviceScopeFactory;
      string busConnectionString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION")!;
      this.busClient = new ServiceBusClient(busConnectionString);
      this.processor = this.busClient.CreateProcessor("user_create", new ServiceBusProcessorOptions());
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {

      this.processor.ProcessMessageAsync += this.MessageHandler;
      this.processor.ProcessErrorAsync += this.ErrorHandler;
      return this.processor.StartProcessingAsync();
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
      Console.WriteLine(args.Exception.ToString());
      return Task.CompletedTask;
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
      User user = JsonSerializer.Deserialize<User>(args.Message.Body)!;
      await args.CompleteMessageAsync(args.Message);
      var scope = this.serviceScopeFactory.CreateScope();
      UserService service = scope.ServiceProvider.GetRequiredService<UserService>();
      await service.AddUser(new User { Name = user.Name });
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
      await this.processor.StopProcessingAsync().ConfigureAwait(false);
    }
  }
}
