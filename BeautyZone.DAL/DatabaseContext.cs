using BeautyZone.DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyZone.DAL
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
