using MerchantApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        [HttpGet]
        [Authorize]
         public async Task<ActionResult<string>> GetSomething()
        {
            return "You are authenticated!";
        }
        [HttpGet("{id:int}")]
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<string>> GetSomething(int id)
        {
            return "You are authorized with the role of admin";
        }
    }
}
