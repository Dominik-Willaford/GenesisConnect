using GenesisConnect.Data.Interface;
using GenesisConnect.Data.Models;
using System.Security.Cryptography;

namespace GenesisConnect.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IApiKeyRepository _apiKeyRepository;

        public AuthRepository(IConfiguration configuration, IUserRepository userRepository, IApiKeyRepository apiKey)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _apiKeyRepository = apiKey;
        }

        public async Task<string> GenerateApiKeyAsync(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var apiKey = GenerateRandomApiKey(); // Generate a secure, random API key
            var hashedApiKey = BCrypt.Net.BCrypt.HashPassword(apiKey);

            var apiKeyEntity = new ApiKey
            {
                UserId = user.Id,
                KeyHash = hashedApiKey
            };

            await _apiKeyRepository.AddApiKeyAsync(apiKeyEntity);

            return apiKey;
        }

        public async Task<bool> IsApiKeyValidAsync(string apiKey)
        {
            var apiKeyEntity = await _apiKeyRepository.GetApiKeyByKeyHashAsync(apiKey);
            if (apiKeyEntity == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(apiKey, apiKeyEntity.KeyHash);
        }

        private string GenerateRandomApiKey()
        {
            var key = new byte[32]; // Generate 32 bytes (256 bits) of randomness
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return Convert.ToBase64String(key); // Convert to base64 string for easier handling
        }
    }
}
