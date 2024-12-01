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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Event entity)
        {
            await _context.Events.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null) throw new KeyNotFoundException($"Event not found.");

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events.Include(t => t.Location).ToArrayAsync();
        }

        public async Task<Event> GetByIDAsync(int id)
        {
            var eventEntity = await _context.Events
                .Include(e => e.Location)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventEntity == null) throw new KeyNotFoundException($"Event with ID {id} not found.");
            return eventEntity;
        }

        public async Task UpdateAsync(Event entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
