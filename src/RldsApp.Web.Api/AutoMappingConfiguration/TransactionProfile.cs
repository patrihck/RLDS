using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
    public class TransactionProfile : Profile
	{
		public TransactionProfile()
		{
			CreateMap<Transaction, Data.Entities.Transaction>()
				.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.Transaction, Transaction>()
				.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
