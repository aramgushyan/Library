using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorBookRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<int> AddAuthorBookAsync(AuthorBook authorbook, CancellationToken token)
        {
            await _context.AuthorBooks.AddAsync(authorbook, token);
            await _context.SaveChangesAsync(token);
            return authorbook.IdAuthorBook;
        }

        public async Task<bool> DeleteAuthorBookAsync(int id, CancellationToken token)
        {
            int rows = await _context.AuthorBooks
                .Where(ab => ab.IdAuthorBook == id)
                .ExecuteDeleteAsync(token);

            return rows > 0;
        }

        public async Task<List<AuthorBook>> GetAllAuthorBookAsync(CancellationToken token)
        {
            return await _context.AuthorBooks.ToListAsync(token);
        }

        public async Task<AuthorBook> GetAuthorBookByIdAsync(int id, CancellationToken token)
        {
            return  await _context.AuthorBooks.FindAsync(id, token);
        }

        public async Task<bool> UpdateAuthorBookAsync(int id, AuthorBook authorbook, CancellationToken token)
        {
            var previousAuthorBook = await _context.AuthorBooks.FindAsync(id, token);
            if (previousAuthorBook == null)
                return false;

            previousAuthorBook.AuthorId = authorbook.AuthorId;
            previousAuthorBook.BookId = authorbook.BookId;
            previousAuthorBook.Comment = authorbook.Comment;

            await _context.SaveChangesAsync(token);
            return true;
        }
    }
}
