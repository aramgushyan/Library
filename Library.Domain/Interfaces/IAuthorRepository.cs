using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        public Task AddAuthorAsync(Author author);
        public Task<bool> UpdateAuthorAsync(int id,Author author);
        public Task<bool> DeleteAuthorAsync(int id);
        public Task<Author> GetAuthorByIdAsync(int id);
    }
}
