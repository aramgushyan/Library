using Library.Domain.Models;
using Library.Services.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("Author/")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _service;

        public AuthorsController (IAuthorService service) 
        {
            _service = service;
        }

        [HttpPost("/author")]
        public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorDto author) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(author);

            return Ok();
        }

        [HttpGet("/author/{id}")]
        public async Task<ActionResult> ViewAuthorByIdAsync(int id) 
        {
            var author = await _service.GetAsync(id);

            if(author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpDelete("/author/{id}")]
        public async Task<IActionResult> DeleteAuthorByIdAsync(int id)
        {
            var isComplited = await _service.DeleteAsync(id);

            if (isComplited == false)
                return NotFound();

            return Ok();
        }

        [HttpPut("/author/update")]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorDto author)
        {
            var isComplited = await _service.UpdateAsync(author);

            if (isComplited == false)
                return NotFound();

            return Ok();
        }
    }
}
