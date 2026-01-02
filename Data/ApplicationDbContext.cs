using JobPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DeveloperProfile> DeveloperProfiles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
    }
}
