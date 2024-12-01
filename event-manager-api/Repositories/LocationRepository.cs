using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.DAL;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly GeneralDbContext _context;

        public LocationRepository(GeneralDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Location entity)
        {
            await _context.Locations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var locationToDelete = await _context.Locations.FindAsync(id);
            if (locationToDelete == null)
                throw new KeyNotFoundException($"Location with ID {id} not found.");

            _context.Locations.Remove(locationToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
           return await _context.Locations.ToArrayAsync();
        }

        public async Task<Location> GetByIDAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
                throw new KeyNotFoundException($"Location with ID {id} not found.");

            return location;
        }

        public async Task UpdateAsync(Location entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
