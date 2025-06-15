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
        public Task<int> AddLibraryAsync(LibraryModel author);
        public Task<bool> UpdateLibraryAsync(int id, LibraryModel author);
        public Task<bool> DeleteLibraryAsync(int id);
        public Task<LibraryModel> GetLibraryByIdAsync(int id);
    }
}
