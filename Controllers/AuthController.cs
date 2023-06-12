using MerchantApi.Data;
using MerchantApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MerchantApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        private string secretKey;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(ApplicationDbContext db, IConfiguration configuration,
            UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager   )
        {
            _db = db;
            _response = new ApiResponse();
           secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
    }
}
