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

        /// <summary>
        /// Удаляет сотрудника по Id.
        /// </summary>
        /// <param name="id">Id сотрудника для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeByIdAsync(int id, CancellationToken token) 
        {
            if (!await _service.DeleteAsync(id, token)) 
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Возвращает сотрудника по Id.
        /// </summary>
        /// <param name="id">Id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные сотрудника.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowEmployeeDto>> GetEmployeeByIdAsync(int id, CancellationToken token) 
        {
            var employee = await _service.GetAsync(id, token);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Возвращает список всех сотрудников.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список сотрудников.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowEmployeeWithoutDetailsDto>>> GetAllEmployeesAsync(CancellationToken token) 
        {
            return await _service.GetAllAsync(token);
        }

        /// <summary>
        /// Добавляет нового сотрудника.
        /// </summary>
        /// <param name="employee">Данные нового сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданного сотрудника.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> AddEmployeeAsync(AddEmployeeDto employee, CancellationToken token) 
        {
            if(!ModelState.IsValid)
                return BadRequest();

            return await _service.AddAsync(employee, token);
        }

        /// <summary>
        /// Обновляет данные сотрудника.
        /// </summary>
        /// <param name="employee">Обновлённые данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
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
