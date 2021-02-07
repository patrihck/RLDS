using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewCurrency
	{
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Acronym { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Symbol { get; set; }

		[Required]
		public bool IsPrefix { get; set; }
	}
}
