using Microsoft.AspNetCore.Identity;

namespace MerchantApi.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
    }
}
