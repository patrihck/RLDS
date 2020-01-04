using System.Collections.Generic;

namespace RldsApp.Data.Entities
{
	public class User : IVersionedEntity
	{
		private readonly IList<Role> _roles = new List<Role>();

		public virtual long UserId { get; set; }

		public virtual string Login { get; set; }

		public virtual string Password { get; set; }

		public virtual string Firstname { get; set; }

		public virtual string Lastname { get; set; }

		public virtual string Email { get; set; }

        public virtual IList<Role> Roles => _roles;

		public virtual byte[] Version { get; set; }
	}
}
