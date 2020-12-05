using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
	public class Recurrence
	{
		public virtual long Id { get; set; }
		public virtual Group Group { get; set; }
		public virtual byte[] Version { get; set; }
	}
}
