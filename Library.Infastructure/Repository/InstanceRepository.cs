using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class InstanceRepository : IInstanceRepository
    {
        private readonly LibraryDbContext _context;

        public InstanceRepository(LibraryDbContext context) 
        {
            _context = context;
        }
        public async Task<int> AddInstanceAsync(Instance instance, CancellationToken token)
        {
            await _context.Instances.AddAsync(instance, token);
            await _context.SaveChangesAsync(token);

            return instance.IdInstance;
        }

        public async Task<bool> DeleteInstanceAsync(int id, CancellationToken token)
        {
            return await _context.Instances.Where(i => i.IdInstance == id).ExecuteDeleteAsync(token) > 0;
        }

        public async Task<List<Instance>> GetAllInstancesAsync(CancellationToken token)
        {
            return await _context.Instances.ToListAsync(token);
        }

        public async Task<Instance> GetInstanceByIdAsync(int id, CancellationToken token)
        {
            return await _context.Instances.FindAsync(id,token);
        }

        public async Task<string> GetLibraryByIdAsync(int id, CancellationToken token) 
        {
            return await _context.Libraries.Where(l => l.IdLibrary == id).Select(l => string.Join(" ", l.Street, l.IdLibrary.ToString())).FirstOrDefaultAsync(token);
        }

        public async Task<string> GetBookByIdAsync(int id, CancellationToken token) 
        {
            return await _context.Books.Where(b => b.IdBook == id).Select(b => b.Title).FirstOrDefaultAsync(token);
        }

        public async Task<bool> UpdateInstanceAsync(int id, Instance instance, CancellationToken token)
        {
            var previousInstance = await _context.Instances.FindAsync(id,token);

            if (previousInstance == null)
                return false;

            previousInstance.LibraryId = instance.LibraryId;
            previousInstance.BookId = instance.BookId;
            previousInstance.BookNumber = instance.BookNumber;
            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
