using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthBasic.Models
{
    public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options){
            

        }
    }
}