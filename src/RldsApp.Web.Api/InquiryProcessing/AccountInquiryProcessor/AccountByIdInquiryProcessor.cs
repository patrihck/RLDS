using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.AccountInquiryProcessor
{
	public class AccountByIdInquiryProcessor : IAccountByIdInquiryProcessor
	{
		private readonly IAccountByIdDataProcessor _dataProcessor;
		private readonly IMapper _automapper;
		private readonly IAccountLinkService _accountLinkService;

		public AccountByIdInquiryProcessor(IAccountByIdDataProcessor dataProcessor, IMapper autoMapper, IAccountLinkService accountLinkService)
		{
			_dataProcessor = dataProcessor;
			_automapper = autoMapper;
			_accountLinkService = accountLinkService;
		}

		public Account GetAccountById(long accountId)
		{
			var accountEntity = _dataProcessor.GetAccountById(accountId);

			if (accountEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.AccountNotFound);
			}

			var account = GetMappedAccount(accountEntity);
			return account;
		}

		public virtual Account GetMappedAccount(Data.Entities.Account accountEntity)
		{
			var account = _automapper.Map<Account>(accountEntity);
			_accountLinkService.AddSelfLink(account);

			return account;
		}
	}
}
