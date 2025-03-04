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
            /*
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest =>dest.DismissDate, opt=> opt.Ignore())
                .ForMember(dest => dest.Messuare, opt => opt.Ignore())
                .ForMember(dest => dest.MessuareId, opt => opt.Ignore())
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ForMember(dest => dest.Helper, opt => opt.Ignore())
                .ForMember(dest => dest.Leader, opt => opt.Ignore())
                .ForMember(dest => dest.Subdivision, opt => opt.Ignore())
                .ReverseMap();
            */
        }
    }
}