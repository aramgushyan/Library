using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{

    [ApiController]
    [Route("api/readers")]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderService _service;

        public ReaderController(IReaderService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowReaderDto>> GetReaderByIdAsync(int id, CancellationToken token)
        {
            var reader = await _service.GetAsync(id, token);

            if (reader == null)
                return NotFound();

            return Ok(reader);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpGet]
        public async Task<ActionResult<List<ShowReaderWithoutDetailsDto>>> GetAllReadersAsync(CancellationToken token) 
        {
            return Ok(await _service.GetAllAsync(token));
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderByIdAsync(int id, CancellationToken token) 
        {
            if (!await _service.DeleteAsync(id,token))
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddReaderAsync(AddReaderDto reader, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _service.AddAsync(reader, token));
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateReaderAsync([FromBody] UpdateReaderDto reader, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _service.UpdateAsync(reader, token))
                return NotFound();

            return NoContent() ;
        }

    }
}
