using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infastructure.Repository
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryDbContext _context;

        public ReaderRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет нового читателя.
        /// </summary>
        /// <param name="reader">Данные читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Id добавленного читателя.</returns>

        public async Task<int> AddReaderAsync(Reader reader, CancellationToken token)
        {
            if(reader == null)
                throw new ArgumentNullException("Reader не может быть null");

            await _context.Readers.AddAsync(reader, token);
            await _context.SaveChangesAsync(token);

            return reader.Id;
        }

        /// <summary>
        /// Удаляет читателя по Id.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если удаление выполнено.</returns>
        public async Task<bool> DeleteReaderAsync(int id, CancellationToken token)
        {
            return await _context.Readers.Where(r => r.Id == id).ExecuteDeleteAsync(token) > 0;
        }

        /// <summary>
        /// Возвращает список всех читателей.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список читателей.</returns>
        public async Task<List<Reader>> GetAllReadersAsync(CancellationToken token)
        {
            return await _context.Readers.ToListAsync(token);
        }

        /// <summary>
        /// Возвращает данные читателя по Id.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Читатель или null, если не найден.</returns>
        public async Task<Reader> GetReaderByIdAsync(int id, CancellationToken token)
        {
            return await _context.Readers.FindAsync(id, token);
        }

        /// <summary>
        /// Возвращает список активных выдач книг читателю.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список строк с информацией о выдачах.</returns>
        public async Task<List<string>> GetActiveBookLendingsByReaderIdAsync(int id, CancellationToken token)
        {
            return await _context.BookLendings
                                 .Where(bl => bl.ReaderId == id && bl.DateReturn == null)
                                 .Select(bl => $"Выдача №{bl.Id}: {bl.Instance.Book.Title}")
                                 .ToListAsync(token);
        }

        /// <summary>
        /// Обновляет данные читателя.
        /// </summary>
        /// <param name="id">Id читателя.</param>
        /// <param name="reader">Новые данные читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>True, если обновление выполнено.</returns>
        public async Task<bool> UpdateReaderAsync(int id, Reader reader, CancellationToken token)
        {
            if (reader == null)
                throw new ArgumentNullException("Reader не может быть null");

            var previousReader = await _context.Readers.FindAsync(id, token);

            if (previousReader == null)
                return false;

            previousReader.Name = reader.Name;
            previousReader.Surname = reader.Surname;
            previousReader.Patronymic = reader.Patronymic;
            previousReader.DateBirth = reader.DateBirth;
            previousReader.PhoneNumber = reader.PhoneNumber;
            previousReader.Email = reader.Email;

            _context.Readers.Update(previousReader);

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
