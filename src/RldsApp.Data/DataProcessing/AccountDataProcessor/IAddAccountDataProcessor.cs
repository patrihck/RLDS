using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.AccountDataProcessor
{
	public interface IAddAccountDataProcessor
	{
		void AddAccount(Account account);
	}
}
