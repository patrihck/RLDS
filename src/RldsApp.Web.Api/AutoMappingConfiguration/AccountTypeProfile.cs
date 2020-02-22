﻿using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class AccountTypeProfile : Profile
	{
		public AccountTypeProfile()
		{
			CreateMap<AccountType, Data.Entities.User>()
						.ForMember(dest => dest.Version, opt => opt.Ignore());
		}

	}
}
