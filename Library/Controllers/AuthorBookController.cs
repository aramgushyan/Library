using Library.Application.Dto;
using Library.Services;
using Library.Services.Interfaces;
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


        [HttpGet("{id}")]
        public async Task<ActionResult<ShowAuthorBookDto>> GetAuthorBookByIdAsync(int id, CancellationToken token) 
        {
            var authorBook = await _serivce.GetByIdAsync(id, token);
            if (authorBook == null)
                return NotFound();

            return Ok(authorBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorBooksByIdAsync(int id, CancellationToken token) 
        {
            if(await _serivce.DeleteAsync(id, token) == false)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowAuthorBookDto>>> GetAllAuthorBookAsync(CancellationToken token)
        {
            return Ok(await _serivce.GetAllAsync(token));
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAuthorBook(AddAuthorBookDto authorBookDto, CancellationToken token) 
        {
            if (authorBookDto == null)
                return BadRequest();

            int id = await _serivce.AddAsync(authorBookDto, token);

            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthorBook([FromBody] UpdateAuthorBookDto authorBookDto, CancellationToken token) 
        {
            if (authorBookDto == null)
                return BadRequest();

            if (await _serivce.UpdateAsync(authorBookDto, token) == false)
                return NotFound();

            return NoContent();
        }

    }
}
