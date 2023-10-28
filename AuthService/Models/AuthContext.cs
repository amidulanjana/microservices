using Microsoft.EntityFrameworkCore;

namespace AuthService.Models
{

  public class AuthContext : DbContext
  {
    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public AuthContext()
    {
    }

    public DbSet<User> Users { get; set; }
  }
}