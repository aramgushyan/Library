using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/libraries")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService) 
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Возвращает библиотеку по Id.
        /// </summary>
        /// <param name="id">Id библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные библиотеки.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowLibraryDto>> GetLibraryByIdAsync(int id, CancellationToken token) 
        {
            var library = await _libraryService.GetAsync(id, token);

            if (library == null)
                return NotFound();

            return Ok(library);
        }

        /// <summary>
        /// Возвращает все библиотеки.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список библиотек.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowLibraryWithoutDetailsDto>>> GetLibrariesAsync(CancellationToken token)
        {
            var library = await _libraryService.GetAllAsync(token);

            return Ok(library);
        }

        /// <summary>
        /// Добавляет новую библиотеку.
        /// </summary>
        /// <param name="libraryDto">Данные новой библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданной библиотеки.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<IActionResult> AddLibraryAsync([FromBody] AddLibraryDto libraryDto, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _libraryService.AddAsync(libraryDto, token));
        }

        /// <summary>
        /// Удаляет библиотеку по Id.
        /// </summary>
        /// <param name="id">Id библиотеки для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryByIdAsync(int id, CancellationToken token) 
        {
            if(await _libraryService.DeleteAsync(id, token))
                return NoContent();

            return NotFound();
        }

        /// <summary>
        /// Обновляет данные библиотеки.
        /// </summary>
        /// <param name="libraryDto">Обновлённые данные библиотеки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateLibraryByIdAsync([FromBody] UpdateLibraryDto libraryDto, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _libraryService.UpdateAsync(libraryDto, token))
                return NoContent();

            return NotFound();
        }


    }
}
