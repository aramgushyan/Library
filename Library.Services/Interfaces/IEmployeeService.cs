using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IEmployeeService
    {

        /// <summary>
        /// Получает список всех сотрудников.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список сотрудников.</returns>
        public Task<List<ShowEmployeeWithoutDetailsDto>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Получает данные сотрудника по id.
        /// </summary>
        /// <param name="id">id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные сотрудника или null, если не найден.</returns>
        public Task<ShowEmployeeDto> GetAsync(int id, CancellationToken token);

        /// <summary>
        /// Удаляет сотрудника по id.
        /// </summary>
        /// <param name="id">id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public Task<bool> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        /// Обновляет данные сотрудника по id.
        /// </summary>
        /// <param name="employee">Новые данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateAsync(UpdateEmployeeDto employee, CancellationToken token);

        /// <summary>
        /// Добавляет нового сотрудника.
        /// </summary>
        /// <param name="employee">Данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного сотрудника.</returns>
        public Task<int> AddAsync(AddEmployeeDto employee, CancellationToken token);
    }
}
