using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IAuthorBookRepository
    {
        public Task<int> AddAuthorBookAsync(AuthorBook authorBook, CancellationToken token);
        public Task<bool> UpdateAuthorBookAsync(int id, AuthorBook authorBook, CancellationToken token);
        public Task<bool> DeleteAuthorBookAsync(int id, CancellationToken token);
        public Task<List<AuthorBook>> GetAllAuthorBookAsync(CancellationToken token);
        public Task<AuthorBook> GetAuthorBookByIdAsync(int id, CancellationToken token);
    }
}
