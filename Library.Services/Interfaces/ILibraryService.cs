using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface ILibraryService
    {
        public Task<int> AddAsync(AddLibraryDto libraryDto, CancellationToken token);
        public Task<ShowLibraryDto> GetAsync(int id, CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateLibraryDto libraryDto, CancellationToken token);
        public Task<List<ShowLibraryWithoutDetailsDto>> GetAllAsync(CancellationToken token);
    }
}
