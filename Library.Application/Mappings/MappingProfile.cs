using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, ShowAuthorWithoutBooksDto>().ReverseMap(); 
            CreateMap<Author, ShowAuthorDto>().ReverseMap();
            CreateMap<AddAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();

            CreateMap<Book, ShowBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, ShowBookWithoutDetailsDto>().ReverseMap();

            CreateMap<Genre, ShowGenreDto>().ReverseMap();
            CreateMap<Genre, UpdateGenreDto>().ReverseMap();
            CreateMap<Genre, AddGenreDto>().ReverseMap();
            CreateMap<Genre, ShowGenreWithoutBooksDto>().ReverseMap();

            CreateMap<LibraryModel, ShowLibraryDto>().ReverseMap();
            CreateMap<LibraryModel, UpdateLibraryDto>().ReverseMap();
            CreateMap<LibraryModel, AddLibraryDto>().ReverseMap();
            CreateMap<LibraryModel, ShowLibraryWithoutDetailsDto>().ReverseMap();
        }
    }
}
