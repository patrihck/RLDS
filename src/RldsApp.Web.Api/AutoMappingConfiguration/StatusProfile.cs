using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RldsApp.Web.Api.Models;


namespace RldsApp.Web.Api.AutoMappingConfiguration
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, Data.Entities.Status>()
                .ForMember(dest => dest.Version, opt => opt.Ignore());

            CreateMap<Data.Entities.Status, Status>()
                .ForMember(dest => dest.Links, opt => opt.Ignore());

        }
    }
}