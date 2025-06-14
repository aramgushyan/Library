using Library.Services;
using Library.Services.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service) 
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowGenreDto>> GetGenreByIdAsync(int id)
        {
            var genre = await _service.GetAsync(id);
            if (genre == null) 
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowGenreDto>>> GetAllGenres()
        {
            var genres = await _service.GetAllGenresAsync();

            if (genres.Count == 0)
                return NoContent();

            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenreAsync([FromBody] AddGenreDto genreDto) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(genreDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id) 
        {
            if(await _service.DeleteAsync(id))
                return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreAsync(int id, [FromBody] UpdateGenreDto genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _service.UpdateAsync(id,genre))
                return NoContent();

            return NotFound();
        }

    }
}
