﻿using AutoMapper;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.AccountMaintenanceProcessor
{
	public class AddAccountMaintenanceProcessor : IAddAccountMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddAccountDataProcessor _dataProcessor;
		private readonly IAccountLinkService _accountLinkService;

		public AddAccountMaintenanceProcessor(IAddAccountDataProcessor dataProcessor, IMapper autoMapper, IAccountLinkService accountLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_accountLinkService = accountLinkService;
		}

		public Account AddAccount(NewAccount newAccount)
		{
			var accountEntity = _autoMapper.Map<Data.Entities.Account>(newAccount);
			_dataProcessor.AddAccount(accountEntity);
			var account = _autoMapper.Map<Account>(accountEntity);
			_accountLinkService.AddSelfLink(account);

			return account;
		}
	}
}
