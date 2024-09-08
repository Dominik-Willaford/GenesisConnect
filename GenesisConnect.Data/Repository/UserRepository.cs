using GenesisConnect.Data.DatabaseContext;
using GenesisConnect.Data.Interface;
using GenesisConnect.Data.Models;

namespace GenesisConnect.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return _context.Users.Where(x => x.Username == username).Single();
        }
    }
}
