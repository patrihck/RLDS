using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
	public interface ITransactionsByDateDataProcessor
	{
		List<Transaction> GetTransactionsByData(DateTime dateTime);
	}
}
