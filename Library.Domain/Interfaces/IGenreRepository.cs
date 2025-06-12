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
        public Task AddGenreAsync(Genre genre);
        public Task<bool> UpdateGenreAsync(int id, Genre genre);
        public Task<bool> DeleteGenreAsync(int id);
        public Task<Genre> GetGenreByIdAsync(int id);
    }
}
