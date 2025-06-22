using Library.Domain.Models;
using Library.Infastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class BookLendingRepository : IBookLendingRepository
    {
        private readonly LibraryDbContext _context;

        public BookLendingRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Добавляет новую запись о выдаче книги.
        /// </summary>
        /// <param name="bookLending">Данные выдачи книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ID созданной записи.</returns>
        public async Task<int> AddBookLendingAsync(BookLending bookLending, CancellationToken token)
        {
            await _context.BookLendings.AddAsync(bookLending, token);
            await _context.SaveChangesAsync(token);

            return bookLending.Id;
        }

        /// <summary>
        /// Удаляет запись о выдаче книги по её ID.
        /// </summary>
        /// <param name="id">ID записи о выдаче книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат удаления.</returns>
        public async Task<bool> DeleteBookLendingAsync(int id, CancellationToken token)
        {
            return await _context.BookLendings.Where(bl => bl.Id == id).ExecuteDeleteAsync(token) > 0;
        }

        /// <summary>
        /// Возвращает список всех записей о выдаче книг.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список записей о выдаче.</returns>
        public async Task<List<BookLending>> GetAllBookLendingAsync(CancellationToken token)
        {
            return await _context.BookLendings.ToListAsync(token);
        }

        public async Task<BookLending> GetBookLendingByIdAsync(int id, CancellationToken token)
        {
            return await _context.BookLendings.FindAsync(id, token);
        }

        /// <summary>
        /// Возвращает номер экземпляра книги по его ID.
        /// </summary>
        /// <param name="id">ID экземпляра книги.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Номер книги.</returns>
        public async Task<string> GetInstanceIdAsync(int id, CancellationToken token)
        {
           return await _context.Instances.Where(i => i.Id == id).Select(i => i.BookNumber).FirstOrDefaultAsync(token);
        }

        /// <summary>
        /// Возвращает ФИО читателя по его ID.
        /// </summary>
        /// <param name="id">ID читателя.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>ФИО читателя.</return
        public async Task<string> GetReaderByIdAsync(int id, CancellationToken token)
        {
            return await _context.Readers.Where(r => r.Id == id).Select(r => NameHelper.GetFullName(r.Name, r.Surname, r.Patronymic)).FirstOrDefaultAsync(token);
        }

        /// <summary>
        /// Обновляет данные записи о выдаче книги.
        /// </summary>
        /// <param name="id">ID записи о выдаче книги.</param>
        /// <param name="bookLending">Обновлённые данные.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Результат обновления.</returns>
        public async Task<bool> UpdateBookLendingAsync(int id, BookLending bookLending, CancellationToken token)
        {
            var previousBookLending = await _context.BookLendings.FindAsync(id, token);

            if (previousBookLending == null)
                return false;

            previousBookLending.ReaderId = bookLending.ReaderId;
            previousBookLending.ReturnPeriod = bookLending.ReturnPeriod;
            previousBookLending.DateReturn = bookLending.DateReturn;
            previousBookLending.DateIssue = bookLending.DateIssue;
            previousBookLending.InstanceId = bookLending.InstanceId;

            _context.BookLendings.Update(previousBookLending);

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
