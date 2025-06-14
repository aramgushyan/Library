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
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _context;

        public LibraryRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task AddLibraryAsync(LibraryModel library)
        {
            await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteLibraryAsync(int id)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library == null)
                return false;

            _context.Libraries.Remove(library);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<LibraryModel> GetLibraryByIdAsync(int id)
        {
            return await _context.Libraries.Include(l => l.Instances).ThenInclude(i => i.Book).Include(l => l.Employees)
                .FirstOrDefaultAsync(l => l.IdLibrary == id);
        }

        public async Task<bool> UpdateLibraryAsync(int id, LibraryModel newLibrary)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library == null)
                return false;

            library.Street = newLibrary.Street;
            library.PhoneNumber = newLibrary.PhoneNumber;
            library.House = newLibrary.House;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
