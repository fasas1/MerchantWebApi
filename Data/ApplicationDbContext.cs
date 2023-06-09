using MerchantApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MerchantApi.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions option) :base(option)
        {      
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
