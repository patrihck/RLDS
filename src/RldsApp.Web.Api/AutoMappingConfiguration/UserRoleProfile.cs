using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class UserRoleProfile : Profile
	{
		public UserRoleProfile()
		{
			CreateMap<UserRole, Data.Entities.UserRole>();

			CreateMap<Data.Entities.UserRole, UserRole>();
		}
	}
}
