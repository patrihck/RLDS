using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Web.Api.Models
{
	public class Category
	{
		public virtual long CategoryId { get; set; }

		public virtual User User { get; set; }

		public virtual string Name { get; set; }

		public virtual string Description { get; set; }
	}
}
