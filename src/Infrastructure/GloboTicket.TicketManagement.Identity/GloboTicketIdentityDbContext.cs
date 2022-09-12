using GloboTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Identity
{
    public class GloboTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GloboTicketIdentityDbContext(DbContextOptions<GloboTicketIdentityDbContext> options) : base(options)
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
                FirstName = "John",
                LastName = "Smith",
                UserName = "johnsmith",
                Email = "john@test.com",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> passwordHasher = new();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<ApplicationUser>().HasData(user);
        }
    }
}
