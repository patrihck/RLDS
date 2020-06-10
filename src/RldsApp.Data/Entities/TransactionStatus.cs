using RldsApp.Common;

namespace RldsApp.Data.Entities
{
	public class TransactionStatus
	{
		public virtual TransactionStatusValue Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Ordinal { get; set; }
	}
}
