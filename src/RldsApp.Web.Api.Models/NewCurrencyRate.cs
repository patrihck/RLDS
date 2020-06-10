using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class NewCurrencyRate
	{
		[Required]
		public Currency SourceCurrency { get; set; }

		[Required]
		public Currency TargetCurrency { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public decimal Rate { get; set; }
	}
}
