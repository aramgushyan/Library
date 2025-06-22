using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IReaderRepository
    {
        /// <summary>
        /// Добавляет нового читателя.
        /// </summary>
        /// <param name="reader">Данные читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного читателя.</returns>
        public Task<int> AddReaderAsync(Reader reader, CancellationToken token);

        /// <summary>
        /// Обновляет данные читателя.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="reader">Новые данные читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление выполнено.</returns>
        public Task<bool> UpdateReaderAsync(int id, Reader reader, CancellationToken token);

        /// <summary>
        /// Удаляет читателя по Id.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление выполнено.</returns>
        public Task<bool> DeleteReaderAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список всех читателей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список читателей.</returns>
        public Task<List<Reader>> GetAllReadersAsync(CancellationToken token);

        /// <summary>
        /// Возвращает данные читателя по Id.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Читатель или null, если не найден.</returns>
        public Task<Reader> GetReaderByIdAsync(int id, CancellationToken token);

        /// <summary>
        /// Возвращает список активных выдач книг читателю.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список строк с информацией о выдачах.</returns>
        public Task<List<string>> GetActiveBookLendingsByReaderIdAsync(int id, CancellationToken token);

    }
}
