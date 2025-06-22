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
    public class BookGenreProfile:Profile
    {
        public BookGenreProfile() 
        {
            CreateMap<BookGenre, ShowBookGenreDto>().ReverseMap();
            CreateMap<BookGenre, UpdateBookGenreDto>().ReverseMap();
            CreateMap<BookGenre, AddBookGenreDto>().ReverseMap();
        }
    }
}
