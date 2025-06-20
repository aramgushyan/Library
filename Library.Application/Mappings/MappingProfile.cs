﻿using AutoMapper;
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

            CreateMap<AuthorBook, ShowAuthorBookDto>().ReverseMap();
            CreateMap<AuthorBook, AddAuthorBookDto>().ReverseMap();
            CreateMap<AuthorBook, UpdateAuthorBookDto>().ReverseMap();

            CreateMap<BookGenre, ShowBookGenreDto>().ReverseMap();
            CreateMap<BookGenre, UpdateBookGenreDto>().ReverseMap();
            CreateMap<BookGenre, AddBookGenreDto>().ReverseMap();

            CreateMap<Instance, ShowInstanceDto>().ReverseMap();
            CreateMap<Instance, ShowInstanceWithoutDetailsDto>().ReverseMap();
            CreateMap<Instance, AddInstanceDto>().ReverseMap();
            CreateMap<Instance, UpdateInstanceDto>().ReverseMap();

            CreateMap<BookLending, ShowBookLendingDto>().ReverseMap();
            CreateMap<BookLending, ShowBookLendingWithoutDetailsDto>().ReverseMap();
            CreateMap<BookLending, UpdateBookLendingDto>().ReverseMap();
            CreateMap<BookLending, AddBookLendingDto>().ReverseMap();

            CreateMap<Reader, ShowReaderDto>().ReverseMap();
            CreateMap<Reader, ShowReaderWithoutDetailsDto>().ReverseMap();
            CreateMap<Reader, UpdateReaderDto>().ReverseMap();
            CreateMap<Reader, AddReaderDto>().ReverseMap();

            CreateMap<Employee, ShowEmployeeDto>().ReverseMap();
            CreateMap<Employee, ShowEmployeeWithoutDetailsDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, AddEmployeeDto>().ReverseMap();
            CreateMap<Employee, ShowEmployeeForTokensDto>().ReverseMap();
        }
    }
}
