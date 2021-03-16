using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
// using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) {}
        
        public DbSet<AnimalClass> AnimalClasses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        
    }
}