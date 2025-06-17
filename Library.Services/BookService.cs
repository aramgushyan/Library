using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Application.Dto;
using Library.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Services.Helpers;
using AutoMapper;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddBookDto bookDto, CancellationToken token)
        {
            if (bookDto == null)
                throw new ArgumentNullException("BookDto не может быть null");

            return await _repository.AddBookAsync(_mapper.Map<Book>(bookDto), token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            return await _repository.DeleteBookAsync(id, token);

        }

        public async Task<List<ShowBookWithoutDetailsDto>> GetAllAsync(CancellationToken token)
        {
            var list = await _repository.GetAllBooksAsync(token);
            return _mapper.Map<List<ShowBookWithoutDetailsDto>>(list);
        }

        public async Task<ShowBookDto> GetAsync(int id, CancellationToken token)
        {
            var book = await _repository.GetBookByIdAsync(id, token);
            if ( book == null)
                return null;

            var genries = await _repository.GetGenriesByBookIdAsync(id, token);
            var author = await _repository.GetAuthorsByBookIdAsync(id, token);
            var instances = await _repository.GetInstancesByBookIdAsync(id, token);

            var bookwithDetails = _mapper.Map<ShowBookDto>(book);

            bookwithDetails.Genres = genries;
            bookwithDetails.Authors = author;
            bookwithDetails.Instances = instances;

            return bookwithDetails;
        }

        public async Task<bool> UpdateAsync(UpdateBookDto bookDto, CancellationToken token)
        {
            if (bookDto == null)
                throw new ArgumentNullException("BookDto не может быть null");

            return await _repository.UpdateBookAsync(bookDto.IdBook, _mapper.Map<Book>(bookDto), token);
        }
    }
}
