using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IGenreRepository
    {

        /// <summary>
        /// Добавляет новый жанр.
        /// </summary>
        /// <param name="genre">Данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного жанра.</returns>
        public Task<int> AddGenreAsync(Genre genre, CancellationToken token);

        /// <summary>
        /// Обновляет данные жанра.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="genre">Новые данные жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если жанр найден и обновлён.</returns>
        public Task<bool> UpdateGenreAsync(int id, Genre genre, CancellationToken token);

        /// <summary>
        /// Удаляет жанр по Id.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если жанр найден и удалён.</returns>
        public Task<bool> DeleteGenreAsync(int id, CancellationToken token);

        /// <summary>
        /// Получает жанр по Id.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Жанр или null, если не найден.</returns>
        public Task<Genre> GetGenreByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список названий книг, связанных с жанром.
        /// </summary>
        /// <param name="id">Id жанра.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список названий книг.</returns>
        public Task<List<string>> GetBooksByGenreIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список жанров.</returns>
        public Task<List<Genre>> GetAllGenresAsync(CancellationToken token);
    }
}
