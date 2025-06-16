using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IAuthorBookService
    {
        public Task<int> AddAsync(AddAuthorBookDto authorBookDto, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateAuthorBookDto authorBookDto, CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<List<ShowAuthorBookDto>> GetAllAsync(CancellationToken token);
        public Task<ShowAuthorBookDto> GetByIdAsync(int id, CancellationToken token);
    }
}
