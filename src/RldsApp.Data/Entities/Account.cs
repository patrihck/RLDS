namespace RldsApp.Data.Entities
{
	public class Account : IVersionedEntity
	{
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual User User { get; set; }
		public virtual Currency Currency { get; set; }
		public virtual Group Group { get; set; }
		public virtual decimal StartAmount { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
