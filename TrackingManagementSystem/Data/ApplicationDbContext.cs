using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackingManagementSystem.Models;

namespace TrackingManagementSystem.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Tracker> trackers { get; set; }
        public DbSet<InvitedUser> invitedUsers { get; set; }
    }
}
