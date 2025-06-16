using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Models;
using Library.Application.Dto;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<int> AddAuthorAsync(AddAuthorDto author, CancellationToken token);
        public Task<ShowAuthorDto> GetAuthorByIdAsync(int id, CancellationToken token);
        public Task<List<ShowAuthorWithoutBooksDto>> GetAllAuthorsAsync(CancellationToken token);
        public Task<bool> DeleteAuhtorAsync(int id, CancellationToken token);
        public Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto author, CancellationToken token);
    }
}
