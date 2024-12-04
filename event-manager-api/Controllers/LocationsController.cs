using Microsoft.AspNetCore.Mvc;
using WebAppWorkshop.Models;
using WebAppWorkshop.Repositories;

namespace event_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IRepository<Location> _repository;
        public LocationsController(IRepository<Location> repository)
        {
            _repository = repository;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Location), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _repository.GetByIDAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLocation(Location location)
        {
            await _repository.UpdateAsync(location);
            return NoContent();
        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            await _repository.AddAsync(location);
            return Ok(location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
