using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infastructure.Helpers;
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

        public async Task<int> AddLibraryAsync(LibraryModel library, CancellationToken token)
        {
            await _context.Libraries.AddAsync(library, token);
            await _context.SaveChangesAsync(token);

            return library.IdLibrary;
        }

        public async Task<bool> DeleteLibraryAsync(int id, CancellationToken token)
        {
            if (await _context.Libraries.FindAsync(id, token) == null)
                return false;

            await _context.Libraries.Where(l => l.IdLibrary == id).ExecuteDeleteAsync(token);

            return true;
        }

        public async Task<List<LibraryModel>> GetAllLibrariesAsync(CancellationToken token)
        {
            return await _context.Libraries.ToListAsync(token);
        }

        public async Task<List<string>> GetEmployeesByLibraryIdAsync(int id, CancellationToken token)
        {
            return await _context.Employees.Where(e => e.LibraryId == id)
                .Select(l => NameHelper.GetFullName(l.Name,l.Surname,l.Patronymic)).ToListAsync(token);
        }

        public async Task<List<Instance>> GetInstancesByLibraryIdAsync(int id, CancellationToken token)
        {
            return await _context.Instances.Where(e => e.LibraryId == id).Include(l=> l.Book).ToListAsync(token);
        }

        public async Task<LibraryModel> GetLibraryByIdAsync(int id, CancellationToken token)
        {
            return await _context.Libraries.FindAsync(id, token);
        }

        public async Task<bool> UpdateLibraryAsync(int id, LibraryModel newLibrary, CancellationToken token)
        {
            var library = await _context.Libraries.FindAsync(id, token);
            if (library == null)
                return false;

            library.Street = newLibrary.Street;
            library.PhoneNumber = newLibrary.PhoneNumber;
            library.House = newLibrary.House;

            await _context.SaveChangesAsync(token);
            return true;
        }
    }
}
