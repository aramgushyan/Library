using Library.Domain.Models;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        /// <summary>
        /// Добавляет нового автора.
        /// </summary>
        /// <param name="author">Данные нового автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданного автора.</returns>
        public Task<int> AddAuthorAsync(Author author, CancellationToken token);

        /// <summary>
        /// Обновляет данные автора.
        /// </summary>
        /// <param name="id">ID автора.</param>
        /// <param name="author">Новые данные автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        public Task<bool> UpdateAuthorAsync(int id,Author author, CancellationToken token);

        /// <summary>
        /// Удаляет автора по его ID.
        /// </summary>
        /// <param name="id">ID автора для удаления.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        public Task<bool> DeleteAuthorAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех авторов.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список авторов.</returns>
        public Task<List<Author>> GetAllAuthorsAsync(CancellationToken token);

        /// <summary>
        /// Возвращает автора по его ID.
        /// </summary>
        /// <param name="id">ID автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные автора.</returns>
        public Task<Author> GetAuthorByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список названий книг, написанных автором.
        /// </summary>
        /// <param name="authorId">ID автора.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список названий книг.</returns>
        public Task<List<string>> GetBooksByAuthorIdAsync(int authorId, CancellationToken token);
    }
}
