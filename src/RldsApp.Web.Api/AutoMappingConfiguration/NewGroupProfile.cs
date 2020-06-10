using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class NewGroupProfile : Profile
	{
		public NewGroupProfile()
		{
			CreateMap<NewGroup, Data.Entities.Group>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Version, opt => opt.Ignore());
		}
	}
}
