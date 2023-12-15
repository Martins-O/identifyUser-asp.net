using IdentityUserCustom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityUserCustom.Datas
{
    public class ApplicationDbContext : IdentityDbContext<UserData>
    {
        public DbSet<UserData> UserDatas { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
