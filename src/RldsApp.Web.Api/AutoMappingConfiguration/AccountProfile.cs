using AutoMapper;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<Models.Account, Data.Entities.Account>()
				.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.Account, Models.Account>()
				.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
