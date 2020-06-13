using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.account
{
	public interface IUpdateAccountDataProcessor
	{
		void UpdateCurrency(Currency currency, long accountId);
		void UpdateGroup(Group group, long accountId);
		void UpdateAccountType(AccountType accountType, long accountId);
		void UpdateBalance(decimal newBalance, long accountId);		
	}
}
