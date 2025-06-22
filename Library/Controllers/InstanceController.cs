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

        /// <summary>
        /// Возвращает экземпляр книги по Id.
        /// </summary>
        /// <param name="id">Id экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные экземпляра книги.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowInstanceDto>> GetInstanceByIdAsync(int id, CancellationToken token) 
        {
            var instance = await _service.GetAsync(id, token);

            if (instance == null)
                return NotFound();

            return Ok(instance);
        }

        /// <summary>
        /// Возвращает список всех экземпляров книг (без деталей).
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список экземпляров книг.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ShowInstanceWithoutDetailsDto>>> GetAllInstancesAsync(CancellationToken token) 
        {
            return Ok(await _service.GetAllAsync(token));
        }

        /// <summary>
        /// Удаляет экземпляр книги по Id.
        /// </summary>
        /// <param name="id">Id экземпляра для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstanceByIdAsync(int id, CancellationToken token)
        {
            if(await _service.DeleteAsync(id,token) == false)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Добавляет новый экземпляр книги.
        /// </summary>
        /// <param name="instanceDto">Данные нового экземпляра книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданного экземпляра.</returns>
        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> AddInstanceAsync(AddInstanceDto instanceDto, CancellationToken token) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.AddAsync(instanceDto, token);
        }

        /// <summary>
        /// Обновляет данные экземпляра книги.
        /// </summary>
        /// <param name="updateInstanceDto">Обновлённые данные экземпляра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
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
