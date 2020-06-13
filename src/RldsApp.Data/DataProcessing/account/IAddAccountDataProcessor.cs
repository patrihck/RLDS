using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.account
{
	public interface IAddAccountDataProcessor
	{
		void AddAccount(Account account);
	}
}
