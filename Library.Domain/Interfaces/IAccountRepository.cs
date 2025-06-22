using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Получает сотрудника по логину.
        /// </summary>
        /// <param name="login">Логин сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект сотрудника или null, если не найден.</returns>
        public Task<Employee> GetByLoginAsync(string login, CancellationToken token);

        /// <summary>
        /// Получает сотрудника по refresh токену.
        /// </summary>
        /// <param name="refreshToken">Refresh токен.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект сотрудника или null, если не найден.</returns>
        public Task<bool> UpdateAsync(Employee employee, CancellationToken token);

        /// <summary>
        /// Обновляет refresh токен и время его истечения для сотрудника.
        /// </summary>
        /// <param name="employee">Обновлённый объект сотрудника с новыми токенами.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно, иначе false.</returns>
        public Task<Employee> GetByRefreshAsync(string refreshToken, CancellationToken token);
    }
}
