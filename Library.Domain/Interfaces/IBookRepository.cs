using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task<int> AddBookAsync(Book book, CancellationToken token);
        public Task<bool> UpdateBookAsync(int id, Book book, CancellationToken token);
        public Task<bool> DeleteBookAsync(int id, CancellationToken token);
        public Task<Book> GetBookByIdAsync(int id, CancellationToken token);
        public Task<List<string>> GetGenriesByBookIdAsync(int id, CancellationToken token);
        public Task<List<string>> GetAuthorsByBookIdAsync(int id, CancellationToken token);
        public Task<List<string>> GetInstancesByBookIdAsync(int id, CancellationToken token);
        public Task<List<Book>> GetAllBooksAsync(CancellationToken token);
    }
}
