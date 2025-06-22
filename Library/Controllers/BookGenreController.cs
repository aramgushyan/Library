using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Возвращает жанр_книги по его Id.
        /// </summary>
        /// <param name="id">Id жанр_книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные жанр_книги.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowBookGenreDto>> GetBookGenreByIdAsync(int id, CancellationToken token) 
        {
            var bookGenre = await _service.GetAsync(id, token);

            if (bookGenre == null)
                return NotFound();

            return Ok(bookGenre);
        }

        /// <summary>
        /// Возвращает список всех жанр_ниг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список жанр_книг.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowBookGenreDto>>> GetAllBookGenresAsync(CancellationToken token)
        {
            return await _service.GetAllAsync(token);
        }

        /// <summary>
        /// Удаляет жанр_книгу по Id.
        /// </summary>
        /// <param name="id">Id жанр_книги для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookGenreByIdAsync(int id, CancellationToken token) 
        {
            if (await _service.DeleteAsync(id, token) == false)
                return NotFound();
            
            return NoContent();
        }

        /// <summary>
        /// Добавляет новый жанр_книги.
        /// </summary>
        /// <param name="bookGenreDto">Данные нового жанр_книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданного жанр_книги.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddBookGenreAsync(AddBookGenreDto bookGenreDto, CancellationToken token) 
        {
            return Ok(await _service.AddAsync(bookGenreDto, token));
        }

        /// <summary>
        /// Обновляет данные жанр_книги.
        /// </summary>
        /// <param name="bookGenreDto">Обновлённые данные жанр_книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateBookGenreAsync([FromBody] UpdateBookGenreDto bookGenreDto, CancellationToken token) 
        {
            if (await _service.UpdateAsync(bookGenreDto, token) == false)
                return NotFound();

            return NoContent();
        }

    }
}
