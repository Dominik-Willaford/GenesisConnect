using GenesisConnect.Authentication.Interface;
using GenesisConnect.Data.Models;
using Microsoft.AspNetCore.Mvc;
using static GenesisConnect.Authentication.Interface.IAuthRepository;

namespace GenesisConnect.Authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] User model)
        {
            try

            {
                var apiKey = await _authRepository.GenerateApiKeyAsync(model.Username);
                return Ok(new { ApiKey = apiKey }); // Return the API key upon successful registration
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log, return error response)
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] ApiKey model)
        {
            try
            {
                var isValid = await _authRepository.IsApiKeyValidAsync(model.KeyHash); // Check if API key is valid
                if (!isValid)
                {
                    return Unauthorized();
                }

                // If API key is valid, return success (no need to generate a token)
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest(ex.Message);
            }
        }
    }
}
