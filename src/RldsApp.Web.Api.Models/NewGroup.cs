using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class NewGroup
	{
		[Required]
		public string Name { get; set; }
		public string Info { get; set; }
		public string Ordinal { get; set; }

	}
}
