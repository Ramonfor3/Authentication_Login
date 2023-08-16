using Authentication_Login.ConfigurationEntities;
using Authentication_Login.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Login
{
    public class UserApplicationDbContext : DbContext
    {
        public UserApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
            this.SeedUsers(modelBuilder);
        }


        private void SeedUsers(ModelBuilder builder)
        {
            Users user = new Users()
            {
                Id = 1,
                Name = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                Password = "123qwe",
                Document = "40324251",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                CreatedBy = "",
                IsModified = false,
                ModifiedDate = DateTime.Now,
                EmailAddress = "admin@gmail.com",
                
                //LockoutEnabled = false,
                //PhoneNumber = "1234567890"
            };

            //PasswordHasher<Users> passwordHasher = new PasswordHasher<Users>();
            //passwordHasher.HashPassword(user, "Admin123");

            builder.Entity<Users>().HasData(user);
        }
        public DbSet<Users> Users { get; set; }
    }
}
