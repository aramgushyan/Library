using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/exportFile/")]
    [Authorize(Roles = "Admin")]
    public class ExportController : ControllerBase
    {
        private readonly LoadService _loadService;
        private const string path = "Tables.xlsx";
        public ExportController(LoadService loadService) 
        {
            _loadService = loadService;
        }

        /// <summary>
        /// Создаёт файл с таблицами.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        [HttpGet("toXML")]
        public async Task<IActionResult> ExportDatabase(CancellationToken token)
        {
            await _loadService.ExportTablesAsync(path, token);

            return NoContent();
        }
    }
}
