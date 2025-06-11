using Library.Domain.Models;
using Library.Services.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/author")]
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

            await _service.AddAsync(author);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowAuthorDto>> ViewAuthorByIdAsync(int id) 
        {
            var author = await _service.GetAsync(id);

            if(author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorByIdAsync(int id)
        {
            var isComplited = await _service.DeleteAsync(id);

            if (isComplited == false)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id,[FromBody] UpdateAuthorDto author)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isComplited = await _service.UpdateAsync(id,author);

            if (isComplited == false)
                return NotFound();

            return NoContent();
        }
    }
}
