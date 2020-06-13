using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.AccountDataProcessor
{
	public interface IAccountByIdDataProcessor
	{
		Account GetAccountById(long accountId);
	}
}
