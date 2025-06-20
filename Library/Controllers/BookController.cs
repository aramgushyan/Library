using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Возвращает книгу по id.
        /// </summary>
        /// <param name="id">id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns> Данные книги.</returns>
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

        /// <summary>
        /// Возвращает список всех книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список книг.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowBookDto>>> GetAllBooksAsync(CancellationToken token)
        {
            var books = await _bookService.GetAllAsync(token);

            return Ok(books);
        }

        /// <summary>
        /// Добавляет новую книгу.
        /// </summary>
        /// <param name="bookDto">Данные новой книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID добавленной книги.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookDto bookDto, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _bookService.AddAsync(bookDto, token));
        }

        /// <summary>
        /// Удаляет книгу по Id.
        /// </summary>
        /// <param name="id">Id книги для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат операции удаления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id, CancellationToken token) 
        {
            var isCorrect = await _bookService.DeleteAsync(id, token);
            if(isCorrect == false)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Обновляет данные книги.
        /// </summary>
        /// <param name="id">Id книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <param name="bookDto">Обновлённые данные книги.</param>
        /// <returns>Результат операции обновления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut()]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookDto bookDto, CancellationToken token)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isCorrect = await _bookService.UpdateAsync(bookDto, token);
            if (isCorrect == false)
                return NotFound();

            return NoContent();
        }
    }
}
