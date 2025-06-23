using Library.Domain.Models;

namespace Library.Services.Interfaces
{
    public interface IPasswordService
    {
        /// <summary>
        /// Создаёт хеш для пароля пользователя.
        /// </summary>
        /// <param name="user">Пользователь, для которого хешируем пароль.</param>
        /// <param name="password">Пароль в обычном виде.</param>
        /// <returns>Хеш пароля.</returns>
        string HashPassword(Employee user, string password);

        /// <summary>
        /// Проверяет, совпадает ли введённый пароль с сохранённым хешем.
        /// </summary>
        /// <param name="user">Пользователь, для которого проверяем пароль.</param>
        /// <param name="hashedPassword">Сохранённый хеш пароля.</param>
        /// <param name="providedPassword">Введённый пароль для проверки.</param>
        /// <returns>True, если пароль правильный.</returns>
        bool VerifyPassword(Employee user, string hashedPassword, string providedPassword);
    }
}
