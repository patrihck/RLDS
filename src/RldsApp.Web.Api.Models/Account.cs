using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class Account : ILinkContaining
	{
		private List<Link> _links;

		[Key]
		public long Id { get; set; }

		[Editable(true)]
		public string Name { get; set; }

		[Editable(true)]
		public User User { get; set; }

		[Editable(false)]
		public Currency Currency { get; set; }

		[Editable(true)]
		public Group Group { get; set; }

		[Editable(false)]
		public decimal StartAmount { get; set; }

		[Editable(false)]
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
