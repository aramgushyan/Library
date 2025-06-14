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
        public Task AddBookAsync(Book book);
        public Task<bool> UpdateBookAsync(int id, Book book);
        public Task<bool> DeleteBookAsync(int id);
        public Task<Book> GetBookByIdAsync(int id);
        public Task<List<Book>> GetAllBooksAsync();
    }
}
