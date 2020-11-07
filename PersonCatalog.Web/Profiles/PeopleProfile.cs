using AutoMapper;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.Helpers;
using PersonCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Extensions.EnumMapping;


namespace PersonCatalog.Web.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            //TODO: Gender Enum
            CreateMap<Person, PersonDTO>()
                .ForMember(
                dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge()))
                .ForMember(
                dest => dest.Relatives,
                opt => opt.MapFrom(src => src.RelativeTo));

            CreateMap<PersonCreateDTO, Person>();
            CreateMap<Person, PersonCreateDTO>();
            //CreateMap<PersonForUpdateDTO, Person>();
        }
    }
}
