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
    public class GenreProfile:Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, ShowGenreDto>().ReverseMap();
            CreateMap<Genre, UpdateGenreDto>().ReverseMap();
            CreateMap<Genre, AddGenreDto>().ReverseMap();
            CreateMap<Genre, ShowGenreWithoutBooksDto>().ReverseMap();
        }
    }
}
