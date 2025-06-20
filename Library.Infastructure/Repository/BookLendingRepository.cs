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

        public async Task<int> AddBookLendingAsync(BookLending bookLending, CancellationToken token)
        {
            await _context.BookLendings.AddAsync(bookLending, token);
            await _context.SaveChangesAsync(token);

            return bookLending.IdBookLending;
        }

        public async Task<bool> DeleteBookLendingAsync(int id, CancellationToken token)
        {
            return await _context.BookLendings.Where(bl => bl.IdBookLending == id).ExecuteDeleteAsync(token) > 0;
        }

        public async Task<List<BookLending>> GetAllBookLendingAsync(CancellationToken token)
        {
            return await _context.BookLendings.ToListAsync(token);
        }

        public async Task<BookLending> GetBookLendingByIdAsync(int id, CancellationToken token)
        {
            return await _context.BookLendings.FindAsync(id, token);
        }

        public async Task<string> GetInstanceIdAsync(int id, CancellationToken token)
        {
           return await _context.Instances.Where(i => i.IdInstance == id).Select(i => i.BookNumber).FirstOrDefaultAsync(token);
        }

        public async Task<string> GetReaderByIdAsync(int id, CancellationToken token)
        {
            return await _context.Readers.Where(r => r.IdReader == id).Select(r => NameHelper.GetFullName(r.Name, r.Surname, r.Patronymic)).FirstOrDefaultAsync(token);
        }

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

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
