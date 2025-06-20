using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/instances")]
    public class InstanceController : ControllerBase
    {
        private readonly IInstanceService _service;

        public InstanceController(IInstanceService service) 
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowInstanceDto>> GetInstanceByIdAsync(int id, CancellationToken token) 
        {
            var instance = await _service.GetAsync(id, token);

            if (instance == null)
                return NotFound();

            return Ok(instance);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowInstanceWithoutDetailsDto>>> GetAllInstancesAsync(CancellationToken token) 
        {
            return Ok(await _service.GetAllAsync(token));
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstanceByIdAsync(int id, CancellationToken token)
        {
            if(await _service.DeleteAsync(id,token) == false)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddInstanceAsync(AddInstanceDto instanceDto, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.AddAsync(instanceDto, token);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateInstanceAsync([FromBody] UpdateInstanceDto updateInstanceDto, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _service.UpdateAsync(updateInstanceDto, token))
                return NotFound();

            return NoContent();
        }
    }
}
