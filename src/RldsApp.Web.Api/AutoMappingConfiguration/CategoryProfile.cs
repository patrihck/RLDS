using AutoMapper;
using RldsApp.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, Data.Entities.Category>()
					.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.Category, Category>();
		}

	}
}
