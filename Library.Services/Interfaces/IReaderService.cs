using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IReaderService
    {
        public Task<int> AddAsync(AddReaderDto reader, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateReaderDto reader, CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<List<ShowReaderWithoutDetailsDto>> GetAllAsync(CancellationToken token);
        public Task<ShowReaderDto> GetAsync(int id, CancellationToken token);
    }
}
