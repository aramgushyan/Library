using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Проверяет логин и пароль.
        /// </summary>
        /// <param name="accountDto">Введённые данные сотрудника.</param>
        /// <param name="token">Токен отмены.</param>
        /// <param name="refreshToken">Новый токен обновления.</param>
        /// <returns>Данные сотрудника при успешной проверке, иначе null.</returns>
        public Task<ShowEmployeeForTokensDto> VerifyHashedPasswordAsync(AccountDto account, CancellationToken token, string refreshToken);

        /// <summary>
        /// Получает данные сотрудника по переданному токену.
        /// </summary>
        /// <param name="refreshToken">Строка токена.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные сотрудника.</returns
        public Task<ShowEmployeeForTokensDto> GetAsync(string refreshToken, CancellationToken token);

        /// <summary>
        /// Обновляет токен сотрудника.
        /// </summary>
        /// <param name="oldEmployee">Старые данные сотрудника.</param>
        /// <param name="refreshToken">Новый токен.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно.</returns>
        public Task<bool> UpdateAsync(ShowEmployeeForTokensDto oldEmployee, string refreshToken, CancellationToken token);

    }
}
