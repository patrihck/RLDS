using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class RecurringTransactionRule : ILinkContaining
	{
		private List<Link> _links;

		[Key]
		public long Id { get; set; }

		[Editable(true)]
		public RecurringTransaction RecurringTransaction { get; set; }

		[Editable(true)]
		public bool IsActive { get; set; }

		[Editable(true)]
		public DateTime? StartDate { get; set; }

		[Editable(true)]
		public DateTime? EndDate { get; set; }

		public byte[] Version { get; set; }

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
