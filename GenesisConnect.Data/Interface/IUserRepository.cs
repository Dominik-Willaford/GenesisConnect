using GenesisConnect.Data.Models;
namespace GenesisConnect.Data.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
    }
}
