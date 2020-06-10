using RldsApp.Common;

namespace RldsApp.Data.Entities
{
	public class TransactionType
	{
		public virtual TransactionTypeValue Id { get; set; }
		public virtual string Name { get; set; }
	}
}
