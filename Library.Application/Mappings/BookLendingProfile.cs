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
    public class BookLendingProfile:Profile
    {
        public BookLendingProfile() 
        {
            CreateMap<BookLending, ShowBookLendingDto>().ReverseMap();
            CreateMap<BookLending, ShowBookLendingWithoutDetailsDto>().ReverseMap();
            CreateMap<BookLending, UpdateBookLendingDto>().ReverseMap();
            CreateMap<BookLending, AddBookLendingDto>().ReverseMap();
        }
    }
}
