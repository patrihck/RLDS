using RldsApp.Data.Entities;
using System.Collections.Generic;

namespace RldsApp.Data.DataProcessing.accountType
{
	public interface IAllAccountTypesDataProcessor
	{
		List<AccountType> GetAccountTypes();
	}
}
