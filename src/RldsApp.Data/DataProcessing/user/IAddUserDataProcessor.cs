using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.user
{
	public interface IAddUserDataProcessor
	{
		void AddCurrency(User user);
	}
}
