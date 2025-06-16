using Library.Domain.Models;
using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _service;

        public AuthorsController (IAuthorService service) 
        {
            _service = service;
        }

        /// <summary>
        ///  Добавляет нового автора.
        /// </summary>
        /// <param name="author">Данные нового автора </param>
        /// <param name="token"> Токен отмены </param>
        /// <returns>ID созданного автора.</returns>
        [HttpPost]
        public async Task<IActionResult> AddAuthorAsync([FromBody] AddAuthorDto author,CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            int id =await _service.AddAuthorAsync(author, token);

            return Ok(id);
        }

        /// <summary>
        /// Возвращает автора по его Id.
        /// </summary>
        /// <param name="id">Id автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные автора.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowAuthorDto>> GetAuthorByIdAsync(int id, CancellationToken token)
        {
            var author = await _service.GetAuthorByIdAsync(id, token);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        /// <summary>
        /// Возвращает список всех авторов.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список авторов.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowAuthorDto>>> GetAuthorsAsync(CancellationToken token)
        {
            var authors = await _service.GetAllAuthorsAsync(token);
            return Ok(authors);
        }

        /// <summary>
        /// Удаляет автора по id.
        /// </summary>
        /// <param name="id">id автора для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorByIdAsync(int id, CancellationToken token)
        {
            var isComplited = await _service.DeleteAuhtorAsync(id, token);

            if (isComplited == false)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Обновляет данные автора.
        /// </summary>
        /// <param name="id">id автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <param name="author"> Обновлённые  данные автора.</param>
        /// <returns> Результат обновления. </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorDto author, int id, CancellationToken token)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isComplited = await _service.UpdateAuthorAsync(id,author, token);

            if (isComplited == false)
                return NotFound();

            return NoContent();
        }
    }
}
