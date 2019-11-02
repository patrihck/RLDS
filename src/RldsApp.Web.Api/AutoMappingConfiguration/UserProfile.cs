using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, Data.Entities.User>()
				.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.User, User>()
				.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
