using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.AccountDataProcessor
{
	public interface IUpdateAccountDataProcessor
	{
		Account UpdateAccount(long accountId, PropertyValueMapType updatedPropertyValueMap);
	}
}
