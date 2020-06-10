using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class NewTransactionProfile : Profile
	{
		public NewTransactionProfile()
		{
			CreateMap<NewTransaction, Data.Entities.Transaction>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Version, opt => opt.Ignore());
		}
	}
}
