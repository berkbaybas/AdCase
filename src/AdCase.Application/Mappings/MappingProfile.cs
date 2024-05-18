using AdCase.Domain.DTO;
using AdCase.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Application.Mappings
{

    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Group, GroupDto > ().ReverseMap();
        }
    }
}
