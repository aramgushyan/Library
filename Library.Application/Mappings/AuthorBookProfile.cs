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
    public class AuthorBookProfile:Profile
    {
        public AuthorBookProfile() 
        {
            CreateMap<AuthorBook, ShowAuthorBookDto>().ReverseMap();
            CreateMap<AuthorBook, AddAuthorBookDto>().ReverseMap();
            CreateMap<AuthorBook, UpdateAuthorBookDto>().ReverseMap();
        }
    }
}
