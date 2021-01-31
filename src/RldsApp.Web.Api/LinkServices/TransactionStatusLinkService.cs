using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class TransactionStatusLinkService : ITransactionStatusLinkService
	{
		private readonly ICommonLinkService _commonLinkService;

		public TransactionStatusLinkService(ICommonLinkService commonLinkService)
		{
			_commonLinkService = commonLinkService;
		}

		public Link GetAllTransactionStatusesLink()
		{
			const string pathFragment = "transactionStatus";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}
	}
}
