using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class NewCurrencyProfile : Profile
	{
		public NewCurrencyProfile()
		{
			CreateMap<NewCurrency, Data.Entities.Currency>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Version, opt => opt.Ignore());
		}
	}
}
