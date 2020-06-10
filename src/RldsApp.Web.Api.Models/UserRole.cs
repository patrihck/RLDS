using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class UserRole
	{
		[Editable(false)]
		public long UserId { get; set; }

		[Editable(false)]
		public long RoleId { get; set; }
	}
}
