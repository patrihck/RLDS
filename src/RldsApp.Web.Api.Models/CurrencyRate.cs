using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class CurrencyRate : ILinkContaining
	{
		private List<Link> _links;

		[Key]
		public Currency SourceCurrency { get; set; }

		[Key]
		public Currency TargetCurrency { get; set; }

		[Key]
		public DateTime Date { get; set; }

		[Editable(true)]
		public decimal Rate { get; set; }

		public virtual byte[] Version { get; set; }

		[Editable(false)]
		public List<Link> Links
		{
			get { return _links ?? (_links = new List<Link>()); }
			set { _links = value; }
		}

		public void AddLink(Link link)
		{
			Links.Add(link);
		}
	}
}
