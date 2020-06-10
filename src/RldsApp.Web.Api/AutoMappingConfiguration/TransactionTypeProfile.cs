using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class TransactionTypeProfile : Profile
	{
		public TransactionTypeProfile()
		{
			CreateMap<TransactionType, Data.Entities.TransactionType>();

			CreateMap<Data.Entities.TransactionType, TransactionType>();
		}
	}
}
