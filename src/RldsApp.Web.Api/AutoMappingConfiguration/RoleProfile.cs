using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class RoleProfile : Profile
	{
		public RoleProfile()
		{
			CreateMap<Role, Data.Entities.Role>()
				.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.Role, Role>()
				.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
