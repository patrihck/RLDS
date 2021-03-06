using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class RecurringRule : ILinkContaining
	{
		private List<Link> _links;

		[Key]
		public long Id { get; set; }

		[Editable(true)]
		public UserLeaf User { get; set; }

		[Editable(true)]
		public Account Sender { get; set; }

		[Editable(true)]
		public Account Receiver { get; set; } 

		[Editable(true)]
		public TransactionCategory Category { get; set; }

		[Editable(true)]
		public Currency Currency { get; set; }

		[Editable(true)]
		public string Description { get; set; }

		[Editable(true)]
		public decimal Amount { get; set; }

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
