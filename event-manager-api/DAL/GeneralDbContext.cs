using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.DAL
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
