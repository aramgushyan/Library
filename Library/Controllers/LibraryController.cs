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

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowLibraryDto>> GetLibraryByIdAsync(int id) 
        {
            var library = await _libraryService.GetAsync(id);

            if (library == null)
                return NotFound();

            return Ok(library);
        }

        [HttpPost]
        public async Task<IActionResult> AddLibrary(AddLibraryDto libraryDto ) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _libraryService.AddAsync(libraryDto);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryById(int id) 
        {
            if(await _libraryService.DeleteAsync(id))
                return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibraryById(int id, [FromBody] UpdateLibraryDto libraryDto) 
        {
            if (await _libraryService.UpdateAsync(id, libraryDto))
                return NoContent();

            return NotFound();
        }


    }
}
