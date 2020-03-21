using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.account
{
	public interface IAccountByIdDataProcessor
	{
		Account GetAccountById(long accountId);
	}
}
