using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.accountType
{
	public interface IAccountTypeByIdDataProcessor
	{
		AccountType GetAccountTypeById(long accountTypeId);
	}
}
