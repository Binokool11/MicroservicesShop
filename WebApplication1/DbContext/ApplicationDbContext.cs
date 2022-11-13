using Authorize.Services.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authorize.Services.IdentityServer.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "164F71AE-DE35-4952-BDA3-FA4833DC3713",
                Name = "Admin",
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "A3D923BF-7C9E-418D-B6EF-343D8A87AA66",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null,"secretePasword"),
                Email = "admin@mail.ru",
                EmailConfirmed = true,
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "164F71AE-DE35-4952-BDA3-FA4833DC3713",
                UserId = "A3D923BF-7C9E-418D-B6EF-343D8A87AA66"
            });
        }
    }
}
