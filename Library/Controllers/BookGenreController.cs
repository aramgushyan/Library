using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/bookGenre")]
    public class BookGenreController : ControllerBase
    {
        private readonly IBookGenreService _service;

        public BookGenreController(IBookGenreService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowBookGenreDto>> GetBookGenreByIdAsync(int id, CancellationToken token) 
        {
            var bookGenre = await _service.GetAsync(id, token);

            if (bookGenre == null)
                return NotFound();

            return Ok(bookGenre);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowBookGenreDto>>> GetAllBookGenresAsync(CancellationToken token)
        {
            return await _service.GetAllAsync(token);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookGenreByIdAsync(int id, CancellationToken token) 
        {
            if (await _service.DeleteAsync(id, token) == false)
                return NotFound();
            
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBookGenreAsync(AddBookGenreDto bookGenreDto, CancellationToken token) 
        {
            return await _service.AddAsync(bookGenreDto, token);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookGenreAsync([FromBody] UpdateBookGenreDto bookGenreDto, CancellationToken token) 
        {
            if (await _service.UpdateAsync(bookGenreDto, token) == false)
                return NotFound();

            return NoContent();
        }

    }
}
