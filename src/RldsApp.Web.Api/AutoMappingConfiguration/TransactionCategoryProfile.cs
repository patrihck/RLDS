using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class TransactionCategoryProfile : Profile
	{
		public TransactionCategoryProfile()
		{
			CreateMap<TransactionCategory, Data.Entities.TransactionCategory>()
				.ForMember(dest =>dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.TransactionCategory, TransactionCategory>()
				.ForMember(dest => dest.Links, opt => opt.Ignore());
		}
	}
}
