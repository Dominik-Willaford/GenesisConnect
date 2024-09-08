namespace GenesisConnect.Data.Interface
{
    public interface IAuthRepository
    {
        Task<string> GenerateApiKeyAsync(string username); // Generate new API key for user
        Task<bool> IsApiKeyValidAsync(string apiKey); // Validate API key
    }
}
