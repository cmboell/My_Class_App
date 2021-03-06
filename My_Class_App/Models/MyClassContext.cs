using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
//my class context model
namespace My_Classes_App.Models
{
    public class MyClassContext : IdentityDbContext<User> //extension
    {
        public MyClassContext(DbContextOptions<MyClassContext> options)
            : base(options)
        { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<Homework> HomeworkAssignments { get; set; }
        public DbSet<HomeworkType> Sprints { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // ClassTeacher set primary key 
            modelBuilder.Entity<ClassTeacher>().HasKey(ct => new { ct.ClassId, ct.TeacherId });
            // ClassTeacher set foreign keys 
            modelBuilder.Entity<ClassTeacher>().HasOne(ct => ct.Class)
                .WithMany(c => c.ClassTeachers)
                .HasForeignKey(ct => ct.ClassId);
            modelBuilder.Entity<ClassTeacher>().HasOne(ct => ct.Teacher)
                .WithMany(t => t.ClassTeachers)
                .HasForeignKey(ct => ct.TeacherId);
            // Class remove cascading delete with ClassType
            modelBuilder.Entity<Class>().HasOne(c => c.ClassType)
                .WithMany(ct => ct.Classes)
                .OnDelete(DeleteBehavior.Restrict);

            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedClassTypes());
            modelBuilder.ApplyConfiguration(new SeedClasses());
            modelBuilder.ApplyConfiguration(new SeedTeachers());
            modelBuilder.ApplyConfiguration(new SeedClassTeachers());
            modelBuilder.ApplyConfiguration(new SeedStatuses());
            modelBuilder.ApplyConfiguration(new SeedHomeworkTypes());
            modelBuilder.ApplyConfiguration(new SeedSchedule());
            modelBuilder.ApplyConfiguration(new SeedDays());
            modelBuilder.ApplyConfiguration(new SeedEventTypes());
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider) //create admin info
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //admin
            string username = "admin";
            string password = "Admin1";
            string roleName = "Admin";

            //creates if doesnt exist
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