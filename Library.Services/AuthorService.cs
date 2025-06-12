using Library.Domain.Models;
using Library.Domain.Interfaces;
using Library.Services.Interfaces;
using Library.Services.Dto;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(AddAuthorDto authorDto)
        {
            await _repository.AddAuthorAsync(new Author()
            {
                Name = authorDto.Name,
                Surname = authorDto.Surname,
                Patronymic = authorDto.Patronymic,

            });
        }

        public async Task<ShowAuthorDto> GetAsync(int id)
        {
            var author = await _repository.GetAuthorByIdAsync(id);
            if(author == null)
                return null;

            return new ShowAuthorDto()
            {
                Id = author.IdAuthor,
                Name = author.Name,
                Surname = author.Surname,
                Patronymic = author.Patronymic
            };
            
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            return await _repository.DeleteAuthorAsync(id);
        }

        public async Task<bool> UpdateAsync(int id,UpdateAuthorDto author)
        {
            return await _repository.UpdateAuthorAsync(id, new Author() 
            {
                Name = author.Name,
                Surname = author.Surname,
                Patronymic = author.Patronymic
            });
        }
    }
}
