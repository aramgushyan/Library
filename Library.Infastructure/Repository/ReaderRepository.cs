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
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryDbContext _context;

        public ReaderRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<int> AddReaderAsync(Reader reader, CancellationToken token)
        {
            await _context.Readers.AddAsync(reader, token);
            await _context.SaveChangesAsync(token);

            return reader.IdReader;
        }

        public async Task<bool> DeleteReaderAsync(int id, CancellationToken token)
        {
            return await _context.Readers.Where(r => r.IdReader == id).ExecuteDeleteAsync(token) > 0;
        }

        public async Task<List<Reader>> GetAllReadersAsync(CancellationToken token)
        {
            return await _context.Readers.ToListAsync(token);
        }

        public async Task<Reader> GetReaderByIdAsync(int id, CancellationToken token)
        {
            return await _context.Readers.FindAsync(id, token);
        }

        public async Task<List<string>> GetActiveBookLendingsByReaderIdAsync(int id, CancellationToken token)
        {
            return await _context.BookLendings
                                 .Where(bl => bl.ReaderId == id && bl.DateReturn == null)
                                 .Select(bl => $"Выдача №{bl.IdBookLending}: {bl.Instance.Book.Title}")
                                 .ToListAsync(token);
        }

        public async Task<bool> UpdateReaderAsync(int id, Reader reader, CancellationToken token)
        {
            var previousReader = await _context.Readers.FindAsync(id, token);

            if (previousReader == null)
                return false;

            previousReader.Name = reader.Name;
            previousReader.Surname = reader.Surname;
            previousReader.Patronymic = reader.Patronymic;
            previousReader.DateBirth = reader.DateBirth;
            previousReader.PhoneNumber = reader.PhoneNumber;
            previousReader.Email = reader.Email;

            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
