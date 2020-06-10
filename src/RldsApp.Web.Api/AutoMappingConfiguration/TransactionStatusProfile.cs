using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class TransactionStatusProfile : Profile
	{
		public TransactionStatusProfile()
		{
			CreateMap<TransactionStatus, Data.Entities.TransactionStatus>();

			CreateMap<Data.Entities.TransactionStatus, TransactionStatus>();
		}
	}
}
