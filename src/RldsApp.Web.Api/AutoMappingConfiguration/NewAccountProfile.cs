using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class NewAccountProfile : Profile
	{
		public NewAccountProfile()
		{
			CreateMap<NewAccount, Data.Entities.Account>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Version, opt => opt.Ignore());
		}
	}
}
