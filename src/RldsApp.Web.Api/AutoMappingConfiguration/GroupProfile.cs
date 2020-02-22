using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, Data.Entities.Group>()
                .ForMember(dest => dest.Version, opt => opt.Ignore());

            CreateMap<Data.Entities.Group, Group>()
                .ForMember(dest => dest.Links, opt => opt.Ignore());
        }
    }
}