using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowBookDto>> GetBookByIdAsync(int id, CancellationToken token)
        {
            var book = await _bookService.GetAsync(id, token);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowBookDto>>> GetAllBooksAsync(CancellationToken token)
        {
            var book = await _bookService.GetAllBooksAsync(token);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookDto bookDto, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

           int id = await _bookService.AddAsync(bookDto, token);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id, CancellationToken token) 
        {
            var isCorrect = await _bookService.DeleteAsync(id, token);
            if(isCorrect == false)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, CancellationToken token, [FromBody]UpdateBookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isCorrect = await _bookService.UpdateAsync(id, bookDto, token);
            if (isCorrect == false)
                return NotFound();

            return NoContent();
        }
    }
}
