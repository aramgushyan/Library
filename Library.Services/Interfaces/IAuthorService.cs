using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Models;
using Library.Services.Dto;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task AddAuthorAsync(AddAuthorDto author);
        public Task<ShowAuthorDto> GetAuthorByIdAsync(int id);
        public Task<List<ShowAuthorDto>> GetAllAuthorsAsync();
        public Task<bool> DeleteAuhtorAsync(int id);
        public Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto author);
    }
}
