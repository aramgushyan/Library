using Library.Domain.Models;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _library;

        public AuthorRepository(LibraryDbContext library) 
        {
            _library = library;
        }

        public async Task<int> AddAuthorAsync(Author author)
        {
            await _library.Authors.AddAsync(author);

            await _library.SaveChangesAsync();

            return author.IdAuthor;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _library.Authors.FindAsync(id);
            if (author != null) 
            {
                _library.Authors.Remove(author);

                await _library.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _library.Authors.Include(a => a.AuthorBooks)
                .ThenInclude(ab => ab.Book).ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _library.Authors.Include(a => a.AuthorBooks)
                .ThenInclude(ab => ab.Book)
                .FirstOrDefaultAsync(a => a.IdAuthor == id);
        }

        public async Task<bool> UpdateAuthorAsync(int id, Author author)
        {
            var pastAuthor = await _library.Authors.FindAsync(id);

            if (pastAuthor != null)
            {
                pastAuthor.Surname = author.Surname;
                pastAuthor.Patronymic = author.Patronymic;
                pastAuthor.Name = author.Name;

                await _library.SaveChangesAsync();

                return true;
            }
            else
                return false;
        }
    }
}
