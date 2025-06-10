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

        public async Task AddAsync(AuthorDto authorDto)
        {
            if (authorDto == null) throw new ArgumentNullException("Author cannot be null");
            

            await _repository.AddAuthorAsync(new Author()
            {
                Name = authorDto.Name,
                Surname = authorDto.Surname,
                Patronymic = authorDto.Patronymic,

            });
        }

        public async Task<AuthorDto> GetAsync(int id)
        {
            try
            {
                var author = await _repository.GetAuthorById(id);
                return new AuthorDto()
                {
                    Name = author.Name,
                    Surname = author.Surname,
                    Patronymic = author.Patronymic
                };
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
