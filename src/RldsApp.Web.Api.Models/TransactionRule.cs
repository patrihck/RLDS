using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class TransactionRule : ILinkContaining
	{
		private List<Link> _links;

		[Key]
		public virtual long Id { get; set; }

		[Editable(true)]
		public virtual DateTime DateFrom { get; set; }

		[Editable(true)]
		public virtual DateTime DateTo { get; set; }

		[Editable(true)]
		public virtual User User { get; set; }

		[Editable(true)]
		public virtual Account Sender { get; set; }

		[Editable(true)]
		public virtual Account Receiver { get; set; }

		[Editable(true)]
		public virtual TransactionCategory Category { get; set; }

		[Editable(true)]
		public virtual Currency Currency { get; set; }

		[Editable(true)]
		public virtual string Description { get; set; }

		[Editable(true)]
		public virtual decimal Amount { get; set; }

		[Editable(true)]
		public virtual Recurrence Period { get; set; }

		[Editable(true)]
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
