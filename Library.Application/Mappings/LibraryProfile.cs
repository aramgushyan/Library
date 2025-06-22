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
    public class LibraryProfile:Profile
    {
        public LibraryProfile() 
        {
            CreateMap<LibraryModel, ShowLibraryDto>().ReverseMap();
            CreateMap<LibraryModel, UpdateLibraryDto>().ReverseMap();
            CreateMap<LibraryModel, AddLibraryDto>().ReverseMap();
            CreateMap<LibraryModel, ShowLibraryWithoutDetailsDto>().ReverseMap();
        }
    }
}
