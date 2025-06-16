using Library.Domain.Models;
using Library.Domain.Interfaces;
using Library.Services.Interfaces;
using Library.Application.Dto;
using AutoMapper;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAuthorAsync(AddAuthorDto authorDto, CancellationToken token)
        {
            return await _repository.AddAuthorAsync(_mapper.Map<Author>(authorDto), token);
        }

        public async Task<bool> DeleteAuhtorAsync(int id, CancellationToken token) 
        {
            return await _repository.DeleteAuthorAsync(id,token);
        }

        public async Task<bool> UpdateAuthorAsync(int id,UpdateAuthorDto author, CancellationToken token)
        {

            return await _repository.UpdateAuthorAsync(id, _mapper.Map<Author>(author), token);
        }

        public async Task<ShowAuthorDto> GetAuthorByIdAsync(int id, CancellationToken token)
        {
            var author = await _repository.GetAuthorByIdAsync(id, token);
            if (author == null)
                return null;

            var books = await _repository.GetBooksByAuthorIdAsync(id, token);

            var authorWithBook = _mapper.Map<ShowAuthorDto>(author);
            authorWithBook.Books = books;

            return authorWithBook;
        }

        public async Task<List<ShowAuthorWithoutBooksDto>> GetAllAuthorsAsync(CancellationToken token)
        {
            var list = await  _repository.GetAllAuthorsAsync(token);

            return _mapper.Map<List<ShowAuthorWithoutBooksDto>>(list);
        }
    }
}
