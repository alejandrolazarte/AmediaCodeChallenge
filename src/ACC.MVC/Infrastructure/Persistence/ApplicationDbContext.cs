using ACC.MVC.Domain;
using Microsoft.EntityFrameworkCore;

namespace ACC.MVC.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(userRole => userRole.Id)
                .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(userRole => userRole.Id)
                .IsRequired();
            });


            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            var adminUser = new User()
            {
                Id = 1,
                Email = "admin@gmail.com",
                Name = "adminUser",
                Password = "admin"
            };

            var visitorUser = new User()
            {
                Id = 2,
                Email = "visitor@gmail.com",
                Name = "visitorUser",
                Password = "visitor"
            };

            var rolAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
            };

            var rolVisitor = new Role()
            {
                Id = 2,
                Name = "Visitor",
            };

            var roles = new List<object>()
            {
                rolAdmin,
                rolVisitor
            };

            var users = new List<object>()
            {
                adminUser,
                visitorUser
            };

            builder.Entity<Role>().HasData(roles);
            builder.Entity<User>().HasData(users);

            var userRoleAdmin = new UserRole()
            {
                Id = 1,
                RoleId = rolAdmin.Id,
                UserId = adminUser.Id
            };

            var userRoleVendedor = new UserRole()
            {
                Id = 2,
                RoleId = rolVisitor.Id,
                UserId = visitorUser.Id
            };
            var userRoles = new List<object>()
            {
                userRoleAdmin,
                userRoleVendedor
            };

            builder.Entity<UserRole>().HasData(userRoles);
        }

    }
}
