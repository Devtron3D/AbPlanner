using AbPlanner.DataAccess.Models;
using AbPlanner.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AbPlanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudiobookController(IAudiobookRepository repository) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Audiobook>> Get(int id)
        {
            var audiobook = await repository.GetAsync(id);
            if (audiobook == null)
            {
                return NotFound();
            }
            return Ok(audiobook);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Audiobook>>> GetAll()
        {
            var audiobooks = await repository.GetAllAsync();
            return Ok(audiobooks);
        }

        [HttpPost]
        public async Task<ActionResult<Audiobook>> Create(Audiobook entity)
        {
            var createdAudiobook = await repository.CreateAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = createdAudiobook.Id }, createdAudiobook);
        }

        [HttpPut]
        public async Task<ActionResult<Audiobook>> Update(Audiobook entity)
        {
            var existingAudiobook = await repository.GetAsync(entity.Id);
            return CreatedAtAction(nameof(Update), new { id = existingAudiobook!.Id }, existingAudiobook);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingAudiobook = await repository.GetAsync(id);
            if (existingAudiobook == null)
            {
                return NotFound();
            }
            await repository.DeleteAsync(id);
            return NoContent();

        }
    }
}


//public Task<Audiobook?> GetAsync(int id);
//public Task<ICollection<Audiobook>> GetAllAsync();
//public Task<Audiobook> CreateAsync(Audiobook entity);
//public Task<Audiobook> UpdateAsync(Audiobook entity);
//public Task DeleteAsync(int id);