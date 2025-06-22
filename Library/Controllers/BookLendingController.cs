using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{

    [ApiController]
    [Route("api/bookLendings")]
    public class BookLendingController : ControllerBase
    {
        private IBookLendingService _service;

        public BookLendingController(IBookLendingService service)
        {
            _service = service;
        }

        /// <summary>
        /// Возвращает выдачу книги по её Id.
        /// </summary>
        /// <param name="id">Id выдачи книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные выдачи книги.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowBookLendingDto>> GetBookLendingByidAsync(int id, CancellationToken token)
        {
            var bookLending = await _service.GetAsync(id, token);

            if (bookLending == null)
                return NotFound();

            return Ok(bookLending);
        }

        /// <summary>
        /// Возвращает список всех выдач книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список выдач книг.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowBookLendingWithoutDetailsDto>>> GetAllBookLendingAsync(CancellationToken token)
        {
            return Ok(await _service.GetAllAsync(token));
        }

        /// <summary>
        /// Удаляет выдачу книги по Id.
        /// </summary>
        /// <param name="id">Id выдачи книги для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookLendingByIdAsync(int id, CancellationToken token) 
        {
            if(!await _service.DeleteAsync(id, token))
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Добавляет новую выдачу книги.
        /// </summary>
        /// <param name="bookLendingDto">Данные новой выдачи книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданной выдачи.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddBookLendingAsync(AddBookLendingDto bookLendingDto, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _service.AddAsync(bookLendingDto, token));
        }

        /// <summary>
        /// Обновляет данные выдачи книги.
        /// </summary>
        /// <param name="bookLendingDto">Обновлённые данные выдачи книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateBookLendingAsync(UpdateBookLendingDto bookLendingDto, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _service.UpdateAsync(bookLendingDto, token))
                return NotFound();

            return NoContent() ;
        }
    }
}
