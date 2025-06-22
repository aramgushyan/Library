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
    public class ReaderProfile:Profile
    {
        public ReaderProfile() 
        {
            CreateMap<Reader, ShowReaderDto>().ReverseMap();
            CreateMap<Reader, ShowReaderWithoutDetailsDto>().ReverseMap();
            CreateMap<Reader, UpdateReaderDto>().ReverseMap();
            CreateMap<Reader, AddReaderDto>().ReverseMap();
        }
    }
}
