using eTicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTicketManagement.Identity
{
    public class ETicketManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ETicketManagementIdentityDbContext(DbContextOptions<ETicketManagementIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
        }

        private static void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new()
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> passwordHasher = new();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(user);
        }
    }
}
