using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.DAL;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.Repositories
{
    public class CRepo : IRepository<Location>
    {
        private readonly GeneralDbContext _generalDbContext;
        public CRepo(GeneralDbContext generalDb )
        {
            _generalDbContext = generalDb;
        }
        public async Task AddAsync(Location entity)
        {
            await _generalDbContext.locations.AddAsync(entity);
            await _generalDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var c2dl = await _generalDbContext.locations.FindAsync(id);
            if (c2dl != null) {
                _generalDbContext.locations.Remove(c2dl);
                await _generalDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
           return await _generalDbContext.locations.ToArrayAsync();
        }

        public async Task<Location> GetByIDAsync(int id)
        {
            return await _generalDbContext.locations.FindAsync(id);
        }

        public async Task UpdateAsync(Location entity)
        {
            _generalDbContext.Entry(entity).State = EntityState.Modified;
            await _generalDbContext.SaveChangesAsync();
        }
    }
}
