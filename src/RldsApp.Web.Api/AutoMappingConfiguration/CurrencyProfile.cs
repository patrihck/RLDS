using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class CurrencyProfile : Profile
	{
		public CurrencyProfile()
		{
			CreateMap<Currency, Data.Entities.Currency>()
				.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.Currency, Currency>()
				.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
