using RldsApp.Data.Entities;
using System.Collections.Generic;

namespace RldsApp.Data.DataProcessing.transactionStatus
{
	public interface IAllTransactionStatusesDataProcessor
	{
		List<TransactionStatus> GetTransactionStatuses();
	}
}
