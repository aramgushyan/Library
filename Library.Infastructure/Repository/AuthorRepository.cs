using Library.Domain.Models;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Dto;

namespace Library.Infastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _library;

        public AuthorRepository(LibraryDbContext library) 
        {
            _library = library;
        }

        public async Task<int> AddAuthorAsync(Author author, CancellationToken token)
        {
            await _library.Authors.AddAsync(author, token);

            await _library.SaveChangesAsync(token);

            return author.IdAuthor;
        }

        public async Task<bool> DeleteAuthorAsync(int id, CancellationToken token)
        {
            return await _library.Authors.Where(a => a.IdAuthor == id).ExecuteDeleteAsync(token) > 0;
        }

        public async Task<List<Author>> GetAllAuthorsAsync(CancellationToken token)
        {
            return await _library.Authors.ToListAsync(token);
        }

        public async Task<Author> GetAuthorByIdAsync(int id, CancellationToken token)
        {
            return await _library.Authors.FindAsync(id, token);
        }

        public  async  Task<List<string>> GetBooksByAuthorIdAsync(int authorId, CancellationToken token)
        {
            return await _library.AuthorBooks.Where(ab => ab.AuthorId == authorId)
                .Join(_library.Books,ab => ab.BookId,b=>b.IdBook,(ab,b) => b.Title).ToListAsync(token);
        }

        public async Task<bool> UpdateAuthorAsync(int id, Author author, CancellationToken token)
        {
            var pastAuthor = await _library.Authors.FindAsync(id, token);

            if (pastAuthor != null)
            {
                pastAuthor.Surname = author.Surname;
                pastAuthor.Patronymic = author.Patronymic;
                pastAuthor.Name = author.Name;

                await _library.SaveChangesAsync(token);

                return true;
            }
            else
                return false;
        }
    }
}
