using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
    public class RecurringRuleProfile : Profile
    {
        public RecurringRuleProfile()
        {
            CreateMap<NewRecurringRule, Data.Entities.RecurringRule>()
                .ForMember(dest => dest.Version, opt => opt.Ignore());

            CreateMap<Data.Entities.RecurringRule, NewRecurringRule>()
                .ForMember(dest => dest.RulePeriod, opt => opt.Ignore());

            CreateMap<RecurringRule, Data.Entities.RecurringRule>();

            CreateMap<Data.Entities.RecurringRule, RecurringRule>()
                .ForMember(dest => dest.Links, opt => opt.Ignore());
        }
    }
}
