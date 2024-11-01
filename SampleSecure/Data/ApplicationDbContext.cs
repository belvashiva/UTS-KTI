using Microsoft.EntityFrameworkCore;
using SampleSecure.Models;

namespace SampleSecure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        // DbSet untuk entitas Student
        public DbSet<Student> Students { get; set; } = null!;

        // DbSet untuk entitas User
        public DbSet<User> Users { get; set; } = null!;
    }
}
