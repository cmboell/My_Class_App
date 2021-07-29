using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace My_Classes_App.Models
{
    public class MyClassContext : IdentityDbContext<User>
    {
        public MyClassContext(DbContextOptions<MyClassContext> options)
            : base(options)
        { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ClassTeacher: set primary key 
            modelBuilder.Entity<ClassTeacher>().HasKey(ct => new { ct.ClassId, ct.TeacherId });

            // ClassTeacher: set foreign keys 
            modelBuilder.Entity<ClassTeacher>().HasOne(ct => ct.Class)
                .WithMany(c => c.ClassTeachers)
                .HasForeignKey(ct => ct.ClassId);
            modelBuilder.Entity<ClassTeacher>().HasOne(ct => ct.Teacher)
                .WithMany(t => t.ClassTeachers)
                .HasForeignKey(ct => ct.TeacherId);

            // Class: remove cascading delete with ClassType
            modelBuilder.Entity<Class>().HasOne(c => c.ClassType)
                .WithMany(ct => ct.Classes)
                .OnDelete(DeleteBehavior.Restrict);

            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedClassTypes());
            modelBuilder.ApplyConfiguration(new SeedClasses());
            modelBuilder.ApplyConfiguration(new SeedTeachers());
            modelBuilder.ApplyConfiguration(new SeedClassTeachers());
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Admin1";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

    }
}