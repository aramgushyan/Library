using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public Task<int> AddAsync(AddBookDto bookDto, CancellationToken token);
        public Task<ShowBookDto> GetAsync(int id, CancellationToken token);
        public Task<List<ShowBookWithoutDetailsDto>> GetAllBooksAsync(CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<bool> UpdateAsync(int id, UpdateBookDto bookDto, CancellationToken token);
    }
}
