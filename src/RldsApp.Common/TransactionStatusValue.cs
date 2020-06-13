namespace RldsApp.Common
{
	public enum TransactionStatusValue : long
	{
		Planned = 100,

		Awaiting = 200,

		Paid = 300,

		Outdated = 400,
	}
}
