using AutoMapper;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.Helpers;
using PersonCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            //TODO: Gender Enum
            CreateMap<Person, PersonDTO>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge()));

            CreateMap<PersonCreateDTO, Person>();
        }
    }
}
