using GenesisConnect.Data.DatabaseContext;
using GenesisConnect.Data.Interface;
using GenesisConnect.Data.Models;

namespace GenesisConnect.Data.Repository
{
    public class ApiKeyRepository : IApiKeyRepository
    {
        private readonly AppDbContext _context;
        public ApiKeyRepository(AppDbContext context) 
        {
            _context = context;
        }

        public Task AddApiKeyAsync(ApiKey apiKey)
        {
            return Task.CompletedTask;
        }
        public Task<ApiKey> GetApiKeyByKeyHashAsync(string apiKeyHash)
        {
            return null;
        }
    }
}
