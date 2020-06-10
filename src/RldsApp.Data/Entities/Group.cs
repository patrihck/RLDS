namespace RldsApp.Data.Entities
{
	public class Group : IVersionedEntity
	{
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Info { get; set; }
		public virtual long Ordinal { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
