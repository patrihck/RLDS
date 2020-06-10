using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class NewAccount
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public Currency Currency { get; set; }

		public Group Group { get; set; }

		[Required]
		public decimal StartAmount { get; set; }
	}
}
