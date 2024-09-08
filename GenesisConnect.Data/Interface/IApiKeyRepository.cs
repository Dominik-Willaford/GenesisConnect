using GenesisConnect.Data.Models;
namespace GenesisConnect.Data.Interface
{
    public interface IApiKeyRepository
    {
        Task AddApiKeyAsync(ApiKey apiKey);
        Task<ApiKey> GetApiKeyByKeyHashAsync(string apiKeyHash);
    }
}
