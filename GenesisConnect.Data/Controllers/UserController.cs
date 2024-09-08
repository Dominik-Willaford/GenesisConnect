using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenesisConnect.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly 

        [HttpGet(Name = "GetUserApiKey")]
        public string GetApiKey(string username, string hashedPassword)
        {

        }
    }
}
