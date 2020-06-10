namespace RldsApp.Data.Entities
{
	public class TransactionCategory : IVersionedEntity
	{
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual TransactionCategory Root { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
