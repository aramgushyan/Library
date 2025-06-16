using Library.Application.Dto;
using Library.Services.Interfaces;
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
            var library = await _libraryService.GetAllLibrariesAsync(token);

            return Ok(library);
        }

        [HttpPost]
        public async Task<IActionResult> AddLibrary([FromBody] AddLibraryDto libraryDto, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _libraryService.AddAsync(libraryDto, token);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryById(int id, CancellationToken token) 
        {
            if(await _libraryService.DeleteAsync(id, token))
                return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibraryById([FromBody] UpdateLibraryDto libraryDto, int id, CancellationToken token) 
        {
            if (await _libraryService.UpdateAsync(id, libraryDto, token))
                return NoContent();

            return NotFound();
        }


    }
}
