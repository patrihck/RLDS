using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.accountType
{
	public interface IAccountTypeByNameDataProcessor
	{
		AccountType GetAccountTypeByName(string name);
	}
}
