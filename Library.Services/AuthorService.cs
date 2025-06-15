using Library.Domain.Models;
using Library.Domain.Interfaces;
using Library.Services.Interfaces;
using Library.Application.Dto;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAuthorAsync(AddAuthorDto authorDto)
        {
           return await _repository.AddAuthorAsync(new Author()
            {
                Name = authorDto.Name,
                Surname = authorDto.Surname,
                Patronymic = authorDto.Patronymic,

            });
        }

        public async Task<bool> DeleteAuhtorAsync(int id) 
        {
            return await _repository.DeleteAuthorAsync(id);
        }

        public async Task<bool> UpdateAuthorAsync(int id,UpdateAuthorDto author)
        {
            return await _repository.UpdateAuthorAsync(id, new Author() 
            {
                Name = author.Name,
                Surname = author.Surname,
                Patronymic = author.Patronymic
            });
        }

        public async Task<ShowAuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _repository.GetAuthorByIdAsync(id);
            if (author == null)
                return null;

            return new ShowAuthorDto()
            {
                Id = author.IdAuthor,
                Name = author.Name,
                Surname = author.Surname,
                Patronymic = author.Patronymic,
                Books = author.AuthorBooks.Select(x => x.Book.Title).ToList()
            };
        }

        public async Task<List<ShowAuthorDto>> GetAllAuthorsAsync()
        {
            var list = await  _repository.GetAllAuthorsAsync();

            return list.Select(a => new ShowAuthorDto
            {
                Id = a.IdAuthor,
                Name = a.Name,
                Surname = a.Surname,
                Patronymic = a.Patronymic,
                Books = a.AuthorBooks.Select(ab => ab.Book.Title).ToList()
            }).ToList();
        }
    }
}
