using RldsApp.Data.Entities;
using System.Collections.Generic;

namespace RldsApp.Data.DataProcessing.account
{
	public interface IAllAccountsDataProcessor
	{
		List<Account> GetAccounts();
	}
}
