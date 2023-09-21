using Blazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Course { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Blazor.Shared.Task> Task { get; set; }
        public DbSet<TaskAnswer> TaskAnswer { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}
