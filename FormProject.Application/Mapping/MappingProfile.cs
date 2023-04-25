using AutoMapper;
using FormProject.Application.Models.DTOs;
using FormProject.Domain.Entities;

namespace FormProject.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //ToDo: Mapping kısmı eklenecek

            CreateMap<AppUser, RegistorDTO>().ReverseMap();
            
            CreateMap<Field, CreteFieldDTO>().ReverseMap();
            CreateMap<Field, UpdateFieldDTO>().ReverseMap();
            
            CreateMap<Form, CreateFormDTO>().ReverseMap();
            CreateMap<Form, UpdateFormDTO>().ReverseMap();


        }
    }
}
