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
        public Task<int> AddBookLendingAsync(BookLending bookLending, CancellationToken token);
        public Task<bool> UpdateBookLendingAsync(int id, BookLending bookLending, CancellationToken token);
        public Task<bool> DeleteBookLendingAsync(int id, CancellationToken token);
        public Task<List<BookLending>> GetAllBookLendingAsync(CancellationToken token);
        public Task<BookLending> GetBookLendingByIdAsync(int id, CancellationToken token);
        public Task<string> GetReaderByIdAsync(int id, CancellationToken token);
        public Task<string> GetInstanceIdAsync(int id, CancellationToken token);
    }
}
