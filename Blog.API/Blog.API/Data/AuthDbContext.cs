using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "c25411a8-8033-4746-b839-e31fb371a04f";
            var writerRoleId = "33860329-3bf6-42d2-af86-840e3a1e1d0e";

            // Create reader and writer role
            var roles = new List<IdentityRole> {
                new IdentityRole(){
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole(){
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                },
            };

            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Creatre an Admin user
            var adminUserId = "f543e3e4-2f1f-44e8-ac79-e18a65571a6a";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@email.com",
                Email = "admin@email.com",
                NormalizedEmail = "admin@email.com".ToUpper(),
                NormalizedUserName = "admin@email.com".ToUpper(),
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Share%2021");
            builder.Entity<IdentityUser>().HasData(admin);

            // Give roles to admin
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new () {
                    UserId = adminUserId,
                    RoleId = readerRoleId,
                },
                new () {
                    UserId = adminUserId,
                    RoleId = writerRoleId,
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
