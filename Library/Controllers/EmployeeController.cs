using Library.Application.Dto;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/employees/")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service) 
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeByIdAsync(int id, CancellationToken token) 
        {
            if (!await _service.DeleteAsync(id, token)) 
                return NotFound();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowEmployeeDto>> GetEmployeeByIdAsync(int id, CancellationToken token) 
        {
            var employee = await _service.GetAsync(id, token);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowEmployeeWithoutDetailsDto>>> GetAllEmployeesAsync(CancellationToken token) 
        {
            return await _service.GetAllAsync(token);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEmployeeAsync(AddEmployeeDto employee, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest();

            return await _service.AddAsync(employee, token);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeByIdAsync(UpdateEmployeeDto employee, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _service.UpdateAsync(employee, token))
                return NotFound();

            return NoContent() ;
        }

    }
}
