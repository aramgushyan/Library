using Library.Application.Dto;
using Library.Services;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Librarian")]
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

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddAuthorBookAsync(AddAuthorBookDto authorBookDto, CancellationToken token) 
        {
            if (authorBookDto == null)
                return BadRequest();

            return Ok(await _serivce.AddAsync(authorBookDto, token));
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorBookAsync([FromBody] UpdateAuthorBookDto authorBookDto, CancellationToken token) 
        {
            if (authorBookDto == null)
                return BadRequest();

            if (await _serivce.UpdateAsync(authorBookDto, token) == false)
                return NotFound();

            return NoContent();
        }

    }
}
