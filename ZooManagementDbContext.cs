using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
// using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) {}
        // public ZooManagementDbContext() : base("ZooManagementDB-DataAnnotations"){}
        
        public DbSet<AnimalClass> AnimalClasses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<Zookeeper> Zookeepers { get; set; }
        
        
    }
}