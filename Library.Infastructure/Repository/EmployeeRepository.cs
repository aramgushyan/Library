using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly LibraryDbContext _context;

        public EmployeeRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет нового сотрудника.
        /// </summary>
        /// <param name="employee">Данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного сотрудника.</returns>
        public async Task<int> AddEmployeeAsync(Employee employee, CancellationToken token)
        {
            await _context.Employees.AddAsync(employee, token);
            await _context.SaveChangesAsync(token);

            return employee.Id;
        }

        /// <summary>
        /// Удаляет сотрудника по Id.
        /// </summary>
        /// <param name="id">Id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteEmployeeByIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees.Where(e => e.Id == id).ExecuteDeleteAsync(token) > 0;
        }

        /// <summary>
        /// Получает список всех сотрудников.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список сотрудников.</returns>
        public async Task<List<Employee>> GetAllEmployeesAsync(CancellationToken token)
        {
            return await _context.Employees.ToListAsync(token);
        }

        /// <summary>
        /// Получает сотрудника по Id.
        /// </summary>
        /// <param name="id">Id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Сотрудник или null, если не найден.</returns>
        public async Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees.FindAsync(id, token);
        }

        /// <summary>
        /// Получает адрес библиотеки, к которой привязан сотрудник.
        /// </summary>
        /// <param name="id">Id сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Адрес библиотеки.</returns>
        public async Task<string> GetLibraryByIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => string.Join(" ", e.Library.Street, e.Library.House))
            .FirstOrDefaultAsync(token);
        }

        /// <summary>
        /// Обновляет данные сотрудника.
        /// </summary>
        /// <param name="id">Id сотрудника для обновления.</param>
        /// <param name="employee">Новые данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>

        public async Task<bool> UpdateEmployeeByIdAsync(int id ,Employee employee, CancellationToken token)
        {
            var previousEmployee = await _context.Employees.FindAsync(id);

            if (previousEmployee == null)
                return false;

            previousEmployee.Name = employee.Name;
            previousEmployee.Surname = employee.Surname;
            previousEmployee.Email = employee.Email;
            previousEmployee.Patronymic = employee.Patronymic;
            previousEmployee.DateBirth = employee.DateBirth;
            previousEmployee.LibraryId = employee.LibraryId;
            previousEmployee.Role = employee.Role;
            previousEmployee.PhoneNumber = employee.PhoneNumber;

            _context.Employees.Update(previousEmployee);

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
