using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{

    [ApiController]
    [Route("api/bookLendings")]
    public class BookLendingController : ControllerBase
    {
        private IBookLendingService _service;

        public BookLendingController(IBookLendingService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowBookLendingDto>> GetBookLendingByidAsync(int id, CancellationToken token)
        {
            var bookLending = await _service.GetAsync(id, token);

            if (bookLending == null)
                return NotFound();

            return Ok(bookLending);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowBookLendingWithoutDetailsDto>>> GetAllBookLendingAsync(CancellationToken token)
        {
            return Ok(await _service.GetAllAsync(token));
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookLendingByIdAsync(int id, CancellationToken token) 
        {
            if(await _service.DeleteAsync(id, token))
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddBookLendingId(AddBookLendingDto bookLendingDto, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _service.AddAsync(bookLendingDto, token));
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateBookLending(UpdateBookLendingDto bookLendingDto, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _service.UpdateAsync(bookLendingDto, token))
                return NotFound();

            return NoContent() ;
        }
    }
}
