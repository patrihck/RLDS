namespace RldsApp.Data.Entities
{
	public class Category : IVersionedEntity
	{
		public virtual long CategoryId { get; set; }

		public virtual User User { get; set; }

		public virtual string Name { get; set; }

		public virtual string Description { get; set; }

		public byte[] Version { get; set; }
	}
}
