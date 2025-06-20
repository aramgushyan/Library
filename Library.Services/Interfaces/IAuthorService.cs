﻿using System;
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
        public Task<ShowAuthorDto> GetAsync(int id, CancellationToken token);
        public Task<List<ShowAuthorWithoutBooksDto>> GetAllAsync(CancellationToken token);
        public Task<bool> DeleteAuhtorAsync(int id, CancellationToken token);
        public Task<bool> UpdateAuthorAsync(UpdateAuthorDto author, CancellationToken token);
    }
}
