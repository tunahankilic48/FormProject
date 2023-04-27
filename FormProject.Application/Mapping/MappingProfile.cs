using AutoMapper;
using FormProject.Application.Models.DTOs;
using FormProject.Domain.Entities;

namespace FormProject.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AppUser, RegistorDTO>().ReverseMap();
            
            CreateMap<Field, CreteFieldDTO>().ReverseMap();
            
            CreateMap<Form, CreateFormDTO>().ReverseMap();



        }
    }
}
