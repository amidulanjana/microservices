using AuthService.Models;
using AuthService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = Environment.GetEnvironmentVariable("DB_CONNECTION");

Console.WriteLine(connection);

// builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<UsersRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
