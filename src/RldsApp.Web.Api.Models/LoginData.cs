using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class LoginData
	{
		[Required]
		public string Login { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
