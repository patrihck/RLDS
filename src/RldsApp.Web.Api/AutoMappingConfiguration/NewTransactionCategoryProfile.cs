using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class NewTransactionCategoryProfile : Profile
	{
		public NewTransactionCategoryProfile()
		{
			CreateMap<NewTransactionCategory, Data.Entities.TransactionCategory>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Version, opt => opt.Ignore());
		}
	}
}
