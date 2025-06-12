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

        public async Task AddAuthorAsync(Author author)
        {
            await _library.Authors.AddAsync(author);

            await _library.SaveChangesAsync();
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
                throw new ArgumentNullException(nameof(author));
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _library.Authors.FindAsync(id);
            if (author == null)
                return null;

            return author;
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
