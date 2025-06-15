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

        [HttpPost]
        public async Task<IActionResult> AddAuthorAsync([FromBody] AddAuthorDto author) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            int id =await _service.AddAuthorAsync(author);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowAuthorDto>> GetAuthorByIdAsync(int id)
        {
            var author = await _service.GetAuthorByIdAsync(id);

            return Ok(author);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowAuthorDto>>> GetAuthorsAsync()
        {
            var authors = await _service.GetAllAuthorsAsync();

            if (authors.Count==0)
                return NoContent();

            return Ok(authors);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorByIdAsync(int id)
        {
            var isComplited = await _service.DeleteAuhtorAsync(id);

            if (isComplited == false)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id,[FromBody] UpdateAuthorDto author)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isComplited = await _service.UpdateAuthorAsync(id,author);

            if (isComplited == false)
                return NotFound();

            return NoContent();
        }
    }
}
