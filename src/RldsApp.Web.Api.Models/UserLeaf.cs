using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class UserLeaf : ILinkContaining
	{
		private List<Link> _links;

		[Key]
		public long Id { get; set; }

		[Editable(true)]
		public string Login { get; set; }

		[Editable(true)]
		public string Password { get; set; }

		[Editable(true)]
		public string Firstname { get; set; }

		[Editable(true)]
		public string Lastname { get; set; }

		[Editable(true)]
		public string Email { get; set; }

		[Editable(false)]
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
