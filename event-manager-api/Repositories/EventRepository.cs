using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.DAL;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly GeneralDbContext _context;
        public EventRepository(GeneralDbContext context)
        {
            _context = context; 
        }
        public async Task AddAsync(Event entity)
        {
            await _context.events.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var a2dl = await _context.events.FindAsync(id);
            if (a2dl != null)
            {
                _context.events.Remove(a2dl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.events.Include(t => t.Location).ToArrayAsync();
        }

        public async Task<Event> GetByIDAsync(int id)
        {
            return await _context.events.Include(t => t.Location).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Event entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
