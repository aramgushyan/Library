using Library.Application.Dto;
using Library.Services;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/authorbooks")]
    public class AuthorBookController : ControllerBase
    {
        private IAuthorBookService _serivce;
        public AuthorBookController(IAuthorBookService service)
        {
            _serivce = service;
        }

        /// <summary>
        /// Возвращает автор-книга по Id.
        /// </summary>
        /// <param name="id">Id автор-книга.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные автор-книга.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowAuthorBookDto>> GetAuthorBookByIdAsync(int id, CancellationToken token) 
        {
            var authorBook = await _serivce.GetByIdAsync(id, token);
            if (authorBook == null)
                return NotFound();

            return Ok(authorBook);
        }

        /// <summary>
        /// Удаляет автор-книга по Id.
        /// </summary>
        /// <param name="id">Id автор-книга для удаления.</param>
        /// <param name="token">Токен отмены.</p
        /// <returns>Результат удаления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorBooksByIdAsync(int id, CancellationToken token) 
        {
            if(await _serivce.DeleteAsync(id, token) == false)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Возвращает список всех автор-книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список автор-книг.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowAuthorBookDto>>> GetAllAuthorBookAsync(CancellationToken token)
        {
            return Ok(await _serivce.GetAllAsync(token));
        }

        /// <summary>
        /// Добавляет автор-книгу.
        /// </summary>
        /// <param name="authorBookDto">Данные автор-книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданной автор-книги.</returns>

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddAuthorBookAsync(AddAuthorBookDto authorBookDto, CancellationToken token) 
        {
            if (authorBookDto == null)
                return BadRequest();

            return Ok(await _serivce.AddAsync(authorBookDto, token));
        }

        /// <summary>
        /// Обновляет данные автор-книги.
        /// </summary>
        /// <param name="authorBookDto">Обновлённые данные автор-книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorBookAsync([FromBody] UpdateAuthorBookDto authorBookDto, CancellationToken token) 
        {
            if (authorBookDto == null)
                return BadRequest();

            if (await _serivce.UpdateAsync(authorBookDto, token) == false)
                return NotFound();

            return NoContent();
        }

    }
}
