using AutoMapper;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Profiles
{
    public class RelativeProfile : Profile
    {
        public RelativeProfile()
        {
            CreateMap<Relation, RelativeDTO>();
            CreateMap<RelativeCreateDTO, Relation>();
            //CreateMap<Relation, RelativeDTOForFilter>()
            //    .ForPath(dest => dest.Name, opts => opts.MapFrom(src => src.PersonTo.Name)).ReverseMap();

        }
    }
}
