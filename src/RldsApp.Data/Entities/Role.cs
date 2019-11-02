namespace RldsApp.Data.Entities
{
	public class Role : IVersionedEntity
	{
		public virtual long RoleId { get; set; }
		public virtual string RoleName { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
