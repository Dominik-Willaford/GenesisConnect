using GenesisConnect.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GenesisConnect.Authentication.DatabaseContext
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
