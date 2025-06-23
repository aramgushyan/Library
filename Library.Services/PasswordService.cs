using Library.Domain.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Library.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<Employee> _hasher = new();

        /// <summary>
        /// Создаёт хеш для пароля пользователя.
        /// </summary>
        /// <param name="user">Пользователь, для которого хешируем пароль.</param>
        /// <param name="password">Пароль в обычном виде.</param>
        /// <returns>Хеш пароля.</returns>
        public string HashPassword(Employee user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        /// <summary>
        /// Проверяет, совпадает ли введённый пароль с сохранённым хешем.
        /// </summary>
        /// <param name="user">Пользователь, для которого проверяем пароль.</param>
        /// <param name="hashedPassword">Сохранённый хеш пароля.</param>
        /// <param name="providedPassword">Введённый пароль для проверки.</param>
        /// <returns>True, если пароль правильный.</returns>
        public bool VerifyPassword(Employee user, string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
