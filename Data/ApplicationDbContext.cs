using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ApexTravels.Data
{
    public class ApplicationDbContext: IdentityUserContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Have Identity set up its own tables by calling its own ModelCreating Implementation
            base.OnModelCreating(modelBuilder);
        }
    }
}
