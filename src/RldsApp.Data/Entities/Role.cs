using System.Collections.Generic;

namespace RldsApp.Data.Entities
{
	public class Role : IVersionedEntity
	{
		private readonly IList<User> _users = new List<User>();

		public virtual long Id { get; set; }
		public virtual string RoleName { get; set; }
		public virtual IList<User> Users => _users;

		public virtual byte[] Version { get; set; }
	}
}
