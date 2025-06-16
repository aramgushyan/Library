using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IGenreRepository
    {
        public Task<int> AddGenreAsync(Genre genre, CancellationToken token);
        public Task<bool> UpdateGenreAsync(int id, Genre genre, CancellationToken token);
        public Task<bool> DeleteGenreAsync(int id, CancellationToken token);
        public Task<Genre> GetGenreByIdAsync(int id, CancellationToken token);
        public Task<List<string>> GetBooksByGenreIdAsync(int id, CancellationToken token);
        public Task<List<Genre>> GetAllGenresAsync(CancellationToken token);
    }
}
