using Microsoft.AspNetCore.Mvc;
using WebAppWorkshop.Models;
using WebAppWorkshop.Repositories;

namespace event_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IRepository<Event> _repository;
        public EventsController(IRepository<Event> repository)
        {
            _repository = repository;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eventById = await _repository.GetByIDAsync(id);
            return eventById == null ? NotFound() : Ok(eventById);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutEvent(Event @event)
        {
            await _repository.UpdateAsync(@event);
            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            await _repository.AddAsync(@event);
            //return Ok(feat);
            return CreatedAtAction(nameof(GetEvent), new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
