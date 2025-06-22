using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IEmployeeRepository
    {

        /// <summary>
        /// Получает список всех сотрудников.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список сотрудников.</returns>
        public Task<List<Employee>> GetAllEmployeesAsync(CancellationToken token);

        /// <summary>
        /// Получает сотрудника по Id.
        /// </summary>
        /// <param name="id">Id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сотрудник или null, если не найден.</returns>
        public Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает адрес библиотеки, к которой привязан сотрудник.
        /// </summary>
        /// <param name="id">Id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Адрес библиотеки.</returns>
        public Task<string> GetLibraryByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Удаляет сотрудника по Id.
        /// </summary>
        /// <param name="id">Id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public Task<bool> DeleteEmployeeByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Добавляет нового сотрудника.
        /// </summary>
        /// <param name="employee">Данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного сотрудника.</returns>
        public Task<int> AddEmployeeAsync(Employee employee, CancellationToken token);

        /// <summary>
        /// Обновляет данные сотрудника.
        /// </summary>
        /// <param name="id">Id сотрудника для обновления.</param>
        /// <param name="employee">Новые данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateEmployeeByIdAsync(int id ,Employee employee, CancellationToken token);
    }
}
