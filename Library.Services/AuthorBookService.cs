using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepository _repository;
        private readonly IMapper _mapper;

        public AuthorBookService(IAuthorBookRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddAuthorBookDto authorBookDto, CancellationToken token)
        {
            if (authorBookDto == null)
                throw new ArgumentNullException("AuthorBook не может быть null");

            return await _repository.AddAuthorBookAsync(_mapper.Map<AuthorBook>(authorBookDto), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteAuthorBookAsync(id, token);
        }

        public async Task<List<ShowAuthorBookDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowAuthorBookDto>>(await _repository.GetAllAuthorBookAsync(token));
        }

        public async Task<ShowAuthorBookDto> GetByIdAsync(int id, CancellationToken token)
        {
            return _mapper.Map<ShowAuthorBookDto>(await _repository.GetAuthorBookByIdAsync(id, token));
        }

        public async Task<bool> UpdateAsync(UpdateAuthorBookDto authorBookDto, CancellationToken token)
        {
            if (authorBookDto == null)
                throw new ArgumentNullException("AuthorBook не может быть null");

            return await _repository.UpdateAuthorBookAsync(authorBookDto.IdAuthorBook,_mapper.Map<AuthorBook>(authorBookDto), token);
        }
    }
}
