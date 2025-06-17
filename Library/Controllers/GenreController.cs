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

        /// <summary>
        /// Возвращает жанр по Id.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные жанра.</returns>
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

        /// <summary>
        /// Возвращает все жанры.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список жанров.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowGenreDto>>> GetAllGenres(CancellationToken token)
        {
            var genres = await _service.GetAllAsync(token);

            return Ok(genres);
        }

        /// <summary>
        /// Добавляет новый жанр.
        /// </summary>
        /// <param name="genreDto">Данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного жанра.</returns>
        [HttpPost]
        public async Task<IActionResult> AddGenreAsync([FromBody] AddGenreDto genreDto, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.AddAsync(genreDto, token);

            return Ok(id);
        }

        /// <summary>
        /// Удаляет жанр по id.
        /// </summary>
        /// <param name="id">id жанра для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат операции удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id, CancellationToken token) 
        {
            if(await _service.DeleteAsync(id, token))
                return NoContent();

            return NotFound();
        }

        /// <summary>
        /// Обновляет информацию о жанре.
        /// </summary>
        /// <param name="id">id жанра для обновления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <param name="genre">Обновлённые данные жанра.</param>
        /// <returns>Результат операции обновления.</returns>
        [HttpPut()]
        public async Task<IActionResult> UpdateGenreAsync([FromBody] UpdateGenreDto genre, CancellationToken token)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _service.UpdateAsync(genre, token))
                return NoContent();

            return NotFound();
        }

    }
}
