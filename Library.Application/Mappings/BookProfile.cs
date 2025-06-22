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
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, ShowBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, ShowBookWithoutDetailsDto>().ReverseMap();
        }
    }
}
