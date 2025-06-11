using Library.Services.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowBookDto>> GetBookAsync(int id)
        {
            var book = await _bookService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost()]
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookDto bookDto) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bookService.AddAsync(bookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id) 
        {
            var isCorrect = await _bookService.DeleteAsync(id);
            if(isCorrect == false)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id,[FromBody]UpdateBookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isCorrect = await _bookService.UpdateAsync(id, bookDto);
            if (isCorrect == false)
                return NotFound();

            return NoContent();
        }
    }
}
