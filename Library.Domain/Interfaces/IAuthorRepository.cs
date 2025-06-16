using Library.Domain.Models;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<int> AddAuthorAsync(Author author, CancellationToken token);
        public Task<bool> UpdateAuthorAsync(int id,Author author, CancellationToken token);
        public Task<bool> DeleteAuthorAsync(int id, CancellationToken token);
        public Task<List<Author>> GetAllAuthorsAsync(CancellationToken token);
        public Task<Author> GetAuthorByIdAsync(int id, CancellationToken token);
        public Task<List<string>> GetBooksByAuthorIdAsync(int authorId, CancellationToken token);



    }
}
