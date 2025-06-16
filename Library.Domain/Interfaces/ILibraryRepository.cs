using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface ILibraryRepository
    {
        public Task<int> AddLibraryAsync(LibraryModel author, CancellationToken token);
        public Task<bool> UpdateLibraryAsync(int id, LibraryModel author, CancellationToken token);
        public Task<bool> DeleteLibraryAsync(int id, CancellationToken token);
        public Task<LibraryModel> GetLibraryByIdAsync(int id, CancellationToken token);
        public Task<List<string>> GetEmployeesByLibraryIdAsync(int id, CancellationToken token);
        public Task<List<Instance>> GetInstancesByLibraryIdAsync(int id, CancellationToken token);

        public Task<List<LibraryModel>> GetAllLibrariesAsync(CancellationToken token);
    }
}
