namespace RldsApp.Data.Entities
{
	public class Currency : IVersionedEntity
	{
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Acronym { get; set; }
		public virtual string Symbol { get; set; }
		public virtual bool IsPrefix { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
