﻿using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<Account, Data.Entities.Account>()
					.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.Account, Account>()
					.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
