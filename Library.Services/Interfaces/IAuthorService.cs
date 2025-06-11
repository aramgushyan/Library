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
        public Task AddAsync(AddAuthorDto author);
        public Task<ShowAuthorDto> GetAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, UpdateAuthorDto author);
    }
}
