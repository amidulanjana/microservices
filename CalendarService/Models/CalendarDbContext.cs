using Microsoft.EntityFrameworkCore;

namespace CalendarService.Models
{

  public class CalendarDbContext : DbContext
  {
    public CalendarDbContext(DbContextOptions<CalendarDbContext> options)
        : base(options)
    {
    }

    public CalendarDbContext()
    {
    }

    public DbSet<User> Users { get; set; }
  }
}