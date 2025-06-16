using Library.Services;
using Library.Application.Dto;
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
        public async Task<ActionResult<ShowGenreDto>> GetGenreByIdAsync(int id, CancellationToken token)
        {
            var genre = await _service.GetAsync(id, token);
            if (genre == null) 
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowGenreDto>>> GetAllGenres(CancellationToken token)
        {
            var genres = await _service.GetAllGenresAsync(token);

            if (genres.Count == 0)
                return NoContent();

            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenreAsync(CancellationToken token,[FromBody] AddGenreDto genreDto) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.AddAsync(genreDto, token);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id, CancellationToken token) 
        {
            if(await _service.DeleteAsync(id, token))
                return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenreAsync(int id, CancellationToken token, [FromBody] UpdateGenreDto genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _service.UpdateAsync(id,genre, token))
                return NoContent();

            return NotFound();
        }

    }
}
