using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Services.Dto;
using Library.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository) 
        {
            _repository = repository;
        }

        public async Task AddAsync(AddBookDto bookDto)
        {
            await _repository.AddBookAsync(new Book() 
            {
                Title = bookDto.Title,
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteBookAsync(id);

        }

        public async Task<List<ShowBookDto>> GetAllBooksAsync()
        {
            var list = await _repository.GetAllBooksAsync();
            return list.Select(book => new ShowBookDto()
            {
                Title = book.Title,
                IdBook = book.IdBook,
                Genres = book.BookGenres.Select(g => g.Genre.Name).ToList(),
                Authors = book.AuthorBooks.Select(a => a.Author.Name + " " + a.Author.Surname
                + " " + a.Author.Patronymic).ToList(),
                Instances = book.Instances.Select(i => i.BookNumber).ToList()
            }).ToList();
        }

        public async Task<ShowBookDto> GetAsync(int id)
        {
            var book = await _repository.GetBookByIdAsync(id);
            if ( book == null)
                return null;

            return new ShowBookDto()
            {
                Title = book.Title,
                IdBook = book.IdBook,
                Genres = book.BookGenres.Select(g => g.Genre.Name).ToList(),
                Authors = book.AuthorBooks.Select(a => a.Author.Name + " " + a.Author.Surname
                + " " + a.Author.Patronymic).ToList(),
                Instances = book.Instances.Select(i => i.BookNumber).ToList()
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateBookDto bookDto)
        {
            return await _repository.UpdateBookAsync(id, new Book() { Title = bookDto.Title });
        }
    }
}
