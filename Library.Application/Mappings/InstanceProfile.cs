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
    public class InstanceProfile:Profile
    {
        public InstanceProfile() 
        {
            CreateMap<Instance, ShowInstanceDto>().ReverseMap();
            CreateMap<Instance, ShowInstanceWithoutDetailsDto>().ReverseMap();
            CreateMap<Instance, AddInstanceDto>().ReverseMap();
            CreateMap<Instance, UpdateInstanceDto>().ReverseMap();
        }
    }
}
