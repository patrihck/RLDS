using RldsApp.Data.Entities;
using System.Collections.Generic;

namespace RldsApp.Data.DataProcessing.transactionState
{
	public interface IAllTransactionStatesDataProcessor
	{
		List<TransactionState> GetTransactionStates();
	}
}
