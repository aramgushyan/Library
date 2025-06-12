using Library.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ILibraryService
    {
        public Task AddAsync(AddLibraryDto libraryDto);
        public Task<ShowLibraryDto> GetAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, UpdateLibraryDto libraryDto);
    }
}
