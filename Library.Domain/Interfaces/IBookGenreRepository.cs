using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IBookGenreRepository
    {

        /// <summary>
        /// Добавляет новую запись жанр-книги.
        /// </summary>
        /// <param name="bookGenre">Данные жанра книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID добавленной записи.</returns>
        public Task<int> AddBookGenreAsync(BookGenre bookGenre, CancellationToken token);

        /// <summary>
        /// Обновляет данные жанра-книги.
        /// </summary>
        /// <param name="id">ID обновляемой записи.</param>
        /// <param name="bookGenre">Новые данные для обновления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно, иначе false.</returns>
        public Task<bool> UpdateBookGenreAsync(int id, BookGenre bookGenre, CancellationToken token);

        /// <summary>
        /// Удаляет запись жанра-книги по Id.
        /// </summary>
        /// <param name="id">ID удаляемой записи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно, иначе false.</returns>
        public Task<bool> DeleteBookGenreAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список книг-жанров.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список записей BookGenre.</returns>
        public Task<List<BookGenre>> GetAllBookGenresAsync(CancellationToken token);

        /// <summary>
        /// Возвращает запись жанра-книги по Id.
        /// </summary>
        /// <param name="id">ID записи.</param>
        /// <param name="token">Токен отмены .</param>
        /// <returns>Объект BookGenre или null, если не найден.</returns>
        public Task<BookGenre> GetBookGenreByIdAsync(int id, CancellationToken token);
    }
}
