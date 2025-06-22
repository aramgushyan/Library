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
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<Employee, ShowEmployeeDto>().ReverseMap();
            CreateMap<Employee, ShowEmployeeWithoutDetailsDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, AddEmployeeDto>().ReverseMap();
            CreateMap<Employee, ShowEmployeeForTokensDto>().ReverseMap();
        }
    }
}
