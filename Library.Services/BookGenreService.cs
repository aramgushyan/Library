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
    public class BookGenreService : IBookGenreService
    {
        private readonly IBookGenreRepository _repository;
        private readonly IMapper _mapper;

        public BookGenreService(IBookGenreRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddBookGenreDto bookGenre, CancellationToken token)
        {
            if (bookGenre == null)
                throw new ArgumentNullException("BookGenre не может быть null");

            return await _repository.AddBookGenreAsync(_mapper.Map<BookGenre>(bookGenre), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteBookGenreAsync(id, token);
        }

        public async Task<List<ShowBookGenreDto>> GetAllAsync(CancellationToken token)
        {
            return _mapper.Map<List<ShowBookGenreDto>>(await _repository.GetAllBookGenresAsync(token));
        }

        public async Task<ShowBookGenreDto> GetAsync(int id, CancellationToken token)
        {
            return _mapper.Map<ShowBookGenreDto>(await _repository.GetBookGenreByIdAsync(id,token));
        }

        public async Task<bool> UpdateAsync(UpdateBookGenreDto bookGenre, CancellationToken token)
        {
            if (bookGenre == null)
                throw new ArgumentNullException("BookGenre не может быть null");

            return await _repository.UpdateBookGenreAsync(bookGenre.Id,_mapper.Map<BookGenre>(bookGenre), token);
        }
    }
}
