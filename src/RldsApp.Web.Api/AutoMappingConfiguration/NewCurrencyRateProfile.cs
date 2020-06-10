using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class NewCurrencyRateProfile : Profile
	{
		public NewCurrencyRateProfile()
		{
			CreateMap<NewCurrencyRate, Data.Entities.CurrencyRate>()
				.PreserveReferences()
				.ForMember(dest => dest.Version, opt => opt.Ignore());
		}
	}
}
