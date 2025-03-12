using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RusRoads.API.DTO;
using RusRoads.API.Entity;

namespace RusRoads.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subdivision,SubdivisionDto>().ReverseMap();
            
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Messuare, MessuareDto>().ReverseMap();
           
        }
    }
}