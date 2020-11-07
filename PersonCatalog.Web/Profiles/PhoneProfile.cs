using AutoMapper;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Profiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<PhoneNumber, PhoneDTO>();
            CreateMap<PhoneCreateDTO, PhoneNumber>();
        }
    }
}
