using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IBookGenreRepository
    {
        public Task<int> AddBookGenreAsync(BookGenre bookGenre, CancellationToken token);
        public Task<bool> UpdateBookGenreAsync(int id, BookGenre bookGenre, CancellationToken token);
        public Task<bool> DeleteBookGenreAsync(int id, CancellationToken token);
        public Task<List<BookGenre>> GetAllBookGenresAsync(CancellationToken token);
        public Task<BookGenre> GetBookGenreByIdAsync(int id, CancellationToken token);
    }
}
