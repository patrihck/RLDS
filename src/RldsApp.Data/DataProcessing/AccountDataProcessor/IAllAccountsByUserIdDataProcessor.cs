using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.AccountDataProcessor
{
	public interface IAllAccountsByUserIdDataProcessor
	{
		QueryResult<Account> GetAccountsByUserId(PagedDataRequest requestInfo,long userId);
	}
}
