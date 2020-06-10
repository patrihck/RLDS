using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class CurrencyRateProfile : Profile
	{
		public CurrencyRateProfile()
		{
			CreateMap<CurrencyRate, Data.Entities.CurrencyRate>()
				.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.CurrencyRate, CurrencyRate>()
				.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
