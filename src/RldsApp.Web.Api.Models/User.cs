using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class User : UserLeaf
	{
		[Editable(false)]
		public List<Role> Roles { get; set; }
	}
}
