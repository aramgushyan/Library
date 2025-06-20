using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookLendingService
    {
        public Task<int> AddAsync(AddBookLendingDto bookLending, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateBookLendingDto bookLending, CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<List<ShowBookLendingWithoutDetailsDto>> GetAllAsync(CancellationToken token);
        public Task<ShowBookLendingDto> GetAsync(int id, CancellationToken token);
    }
}
