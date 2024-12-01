using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.DAL
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> o) : base(o) { }
        public DbSet<Event> events { get; set; }
        public DbSet<Location> locations { get; set; }
    }
}
