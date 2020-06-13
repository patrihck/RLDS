using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.AccountDataProcessor
{
	public interface IAllAccountsDataProcessor
	{
		QueryResult<Account> GetAccounts(PagedDataRequest requestInfo);
	}
}
