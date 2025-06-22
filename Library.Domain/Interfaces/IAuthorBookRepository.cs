using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IAuthorBookRepository
    {

        /// <summary>
        /// Добавляет Автор-Книгу.
        /// </summary>
        /// <param name="authorbook">Объект AuthorBook для добавления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id созданной записи.</returns>
        public Task<int> AddAuthorBookAsync(AuthorBook authorBook, CancellationToken token);

        /// <summary>
        /// Обновляет Автор-Книгу по Id.
        /// </summary>
        /// <param name="id">Id записи для обновления.</param>
        /// <param name="authorbook">Обновлённые данные.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление прошло успешно, иначе false.</returns>
        public Task<bool> UpdateAuthorBookAsync(int id, AuthorBook authorBook, CancellationToken token);

        /// <summary>
        /// Удаляет Автор-Книгу по Id.
        /// </summary>
        /// <param name="id">Id записи для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление прошло успешно, иначе false.</returns>
        public Task<bool> DeleteAuthorBookAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех Автор-Книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список всех записей.</returns>
        public Task<List<AuthorBook>> GetAllAuthorBookAsync(CancellationToken token);

        /// <summary>
        /// Возвращает запись Автор-Книг по Id.
        /// </summary>
        /// <param name="id">Id записи.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект AuthorBook или null, если не найден.</returns>
        public Task<AuthorBook> GetAuthorBookByIdAsync(int id, CancellationToken token);
    }
}
