using Library.Services.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService) 
        {
            _libraryService = libraryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowLibraryDto>> ShowLibraryById(int id) 
        {
            var library = await _libraryService.GetAsync(id);

            if (library == null)
                return NotFound();

            return Ok(library);
        }

        [HttpPost]
        public async Task<IActionResult> AddLibrary([FromBody] AddLibraryDto libraryDto ) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _libraryService.AddAsync(libraryDto);
            return NoContent();
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
