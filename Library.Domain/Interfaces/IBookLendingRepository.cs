using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public interface IBookLendingRepository
    {
        /// <summary>
        /// Добавляет новую запись о выдаче книги.
        /// </summary>
        /// <param name="bookLending">Данные выдачи книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданной записи.</returns>
        public Task<int> AddBookLendingAsync(BookLending bookLending, CancellationToken token);

        /// <summary>
        /// Обновляет данные записи о выдаче книги.
        /// </summary>
        /// <param name="id">ID записи о выдаче книги.</param>
        /// <param name="bookLending">Обновлённые данные.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        public Task<bool> UpdateBookLendingAsync(int id, BookLending bookLending, CancellationToken token);

        /// <summary>
        /// Удаляет запись о выдаче книги по её ID.
        /// </summary>
        /// <param name="id">ID записи о выдаче книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        public Task<bool> DeleteBookLendingAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех записей о выдаче книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список записей о выдаче.</returns>
        public Task<List<BookLending>> GetAllBookLendingAsync(CancellationToken token);

        /// <summary>
        /// Возвращает запись о выдаче книги по ID.
        /// </summary>
        /// <param name="id">ID записи о выдаче книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Данные записи о выдаче.</returns>
        public Task<BookLending> GetBookLendingByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает ФИО читателя по его ID.
        /// </summary>
        /// <param name="id">ID читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ФИО читателя.</returns>
        public Task<string> GetReaderByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает номер экземпляра книги по его ID.
        /// </summary>
        /// <param name="id">ID экземпляра книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Номер книги.</returns>
        public Task<string> GetInstanceIdAsync(int id, CancellationToken token);
    }
}
