using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
	class Category : IVersionedEntity
	{
		public byte[] Version { get ; set; }

		public virtual long CategoryId { get; set; }

		public virtual long UserId { get; set; }

		public virtual string Name { get; set; }

		public virtual string Description { get; set; }
	}
}
