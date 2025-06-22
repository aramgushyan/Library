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
    public class AccountRepository : IAccountRepository
    {
        private readonly LibraryDbContext _context;

        public AccountRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Получает сотрудника по логину.
        /// </summary>
        /// <param name="login">Логин сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект сотрудника или null, если не найден.</returns>
        public async Task<Employee> GetByLoginAsync(string login, CancellationToken token)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Login == login, token);
        }

        /// <summary>
        /// Получает сотрудника по refresh токену.
        /// </summary>
        /// <param name="refreshToken">Refresh токен.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект сотрудника или null, если не найден.</returns>
        public async Task<Employee> GetByRefreshAsync(string refreshToken, CancellationToken token)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken, token);
        }

        /// <summary>
        /// Обновляет refresh токен и время его истечения для сотрудника.
        /// </summary>
        /// <param name="employee">Обновлённый объект сотрудника с новыми токенами.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно, иначе false.</returns>
        public async Task<bool> UpdateAsync(Employee employee,CancellationToken token)
        {
            var previousEmployee = await _context.Employees.FindAsync(employee.Id, token);
            if (previousEmployee == null)
                return false;

            previousEmployee.RefreshToken = employee.RefreshToken;
            previousEmployee.ExpireTime = employee.ExpireTime;

            _context.Employees.Update(previousEmployee);

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
