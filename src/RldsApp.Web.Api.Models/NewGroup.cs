using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class NewGroup
	{
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Info { get; set; }

		[Required(AllowEmptyStrings = false)]
		public int Ordinal { get; set; }
	}
}
