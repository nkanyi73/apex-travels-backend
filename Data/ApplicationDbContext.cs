using ApexTravels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ApexTravels.Data
{
    /*
     * DB Context should be configured to include the tables required from the 
     * Identity Library.
     * Make DB Context inherit from IdentityUserContext<IdentityUser>
     * (Generic Type Parameters)
     */
    public class ApplicationDbContext: IdentityUserContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Have Identity set up its own tables by calling its own ModelCreating Implementation
            base.OnModelCreating(modelBuilder);
        }
    }
}
