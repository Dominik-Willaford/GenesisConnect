using Microsoft.EntityFrameworkCore;
using GenesisConnect.Data.Models;
namespace GenesisConnect.Data.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
    }
}
