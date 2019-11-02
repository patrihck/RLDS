using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class NewUserProfile : Profile
	{
		public NewUserProfile()
		{
			CreateMap<NewUser, Data.Entities.User>()
				.ForMember(dest => dest.UserId, opt => opt.Ignore())
				.ForMember(dest => dest.Version, opt => opt.Ignore())
				.ForMember(dest => dest.Roles, opt => opt.Ignore());
		}
	}
}
